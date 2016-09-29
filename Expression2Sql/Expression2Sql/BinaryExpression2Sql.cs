﻿#region License
/**
 * Copyright (c) 2015, 何志祥 (strangecity@qq.com).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * without warranties or conditions of any kind, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Linq.Expressions;

namespace Expression2Sql
{
    class BinaryExpression2Sql : BaseExpression2Sql<BinaryExpression>
    {
        private void OperatorParser(ExpressionType expressionNodeType, int operatorIndex, SqlBuilder sqlBuilder, bool useIs = false)
        {
            switch (expressionNodeType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    sqlBuilder.Insert(operatorIndex, "\nand");
                    break;
                case ExpressionType.Equal:
                    if (useIs)
                    {
                        sqlBuilder.Insert(operatorIndex, " is");
                    }
                    else
                    {
                        sqlBuilder.Insert(operatorIndex, " =");
                    }
                    break;
                case ExpressionType.GreaterThan:
                    sqlBuilder.Insert(operatorIndex, " >");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    sqlBuilder.Insert(operatorIndex, " >=");
                    break;
                case ExpressionType.NotEqual:
                    if (useIs)
                    {
                        sqlBuilder.Insert(operatorIndex, " is not");
                    }
                    else
                    {
                        sqlBuilder.Insert(operatorIndex, " <>");
                    }
                    break;
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    sqlBuilder.Insert(operatorIndex, "\nor");
                    break;
                case ExpressionType.LessThan:
                    sqlBuilder.Insert(operatorIndex, " <");
                    break;
                case ExpressionType.LessThanOrEqual:
                    sqlBuilder.Insert(operatorIndex, " <=");
                    break;
                default:
                    throw new NotImplementedException("未实现的节点类型" + expressionNodeType);
            }
        }

        private static int GetOperatorPrecedence(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    return 10;
                case ExpressionType.And:
                    return 6;
                case ExpressionType.AndAlso:
                    return 3;
                case ExpressionType.Coalesce:
                case ExpressionType.Assign:
                case ExpressionType.AddAssign:
                case ExpressionType.AndAssign:
                case ExpressionType.DivideAssign:
                case ExpressionType.ExclusiveOrAssign:
                case ExpressionType.LeftShiftAssign:
                case ExpressionType.ModuloAssign:
                case ExpressionType.MultiplyAssign:
                case ExpressionType.OrAssign:
                case ExpressionType.PowerAssign:
                case ExpressionType.RightShiftAssign:
                case ExpressionType.SubtractAssign:
                case ExpressionType.AddAssignChecked:
                case ExpressionType.MultiplyAssignChecked:
                case ExpressionType.SubtractAssignChecked:
                    return 1;
                case ExpressionType.Constant:
                case ExpressionType.Parameter:
                    return 15;
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.Negate:
                case ExpressionType.UnaryPlus:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Decrement:
                case ExpressionType.Increment:
                case ExpressionType.Throw:
                case ExpressionType.Unbox:
                case ExpressionType.PreIncrementAssign:
                case ExpressionType.PreDecrementAssign:
                case ExpressionType.OnesComplement:
                case ExpressionType.IsTrue:
                case ExpressionType.IsFalse:
                    return 12;
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    return 11;
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                    return 7;
                case ExpressionType.ExclusiveOr:
                    return 5;
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.TypeAs:
                case ExpressionType.TypeIs:
                case ExpressionType.TypeEqual:
                    return 8;
                case ExpressionType.LeftShift:
                case ExpressionType.RightShift:
                    return 9;
                case ExpressionType.Or:
                    return 4;
                case ExpressionType.OrElse:
                    return 2;
                case ExpressionType.Power:
                    return 13;
            }
            return 14;
        }

        private static bool NeedsParenthesesLast(Expression parent, Expression child)
        {
            BinaryExpression binaryExpression = parent as BinaryExpression;
            return binaryExpression != null && child == binaryExpression.Right;
        }

        private static bool NeedsParenthesesPrecedence(Expression parent, Expression child)
        {
            int operatorPrecedenceChild = GetOperatorPrecedence(child);
            int operatorPrecedenceParent = GetOperatorPrecedence(parent);
            if (operatorPrecedenceChild == operatorPrecedenceParent)
            {
                var nodeType = parent.NodeType;
                if (nodeType <= ExpressionType.MultiplyChecked)
                {
                    if (nodeType <= ExpressionType.Divide)
                    {
                        switch (nodeType)
                        {
                            case ExpressionType.Add:
                            case ExpressionType.AddChecked:
                                break;
                            case ExpressionType.And:
                            case ExpressionType.AndAlso:
                                return false;
                            default:
                                if (nodeType != ExpressionType.Divide)
                                {
                                    return true;
                                }
                                return NeedsParenthesesLast(parent, child);
                        }
                    }
                    else
                    {
                        if (nodeType == ExpressionType.ExclusiveOr)
                        {
                            return false;
                        }
                        switch (nodeType)
                        {
                            case ExpressionType.Modulo:
                                return NeedsParenthesesLast(parent, child);
                            case ExpressionType.Multiply:
                            case ExpressionType.MultiplyChecked:
                                break;
                            default:
                                return true;
                        }
                    }
                    return false;
                }
                if (nodeType <= ExpressionType.OrElse)
                {
                    if (nodeType != ExpressionType.Or && nodeType != ExpressionType.OrElse)
                    {
                        return true;
                    }
                }
                else
                {
                    if (nodeType != ExpressionType.Subtract && nodeType != ExpressionType.SubtractChecked)
                    {
                        return true;
                    }
                    return NeedsParenthesesLast(parent, child);
                }
                return false;
            }
            return (child.NodeType == ExpressionType.Constant && (parent.NodeType == ExpressionType.Negate || parent.NodeType == ExpressionType.NegateChecked)) || operatorPrecedenceChild < operatorPrecedenceParent;
        }

        private static bool IsNeedsParentheses(Expression parent, Expression child)
        {
            if (child == null)
            {
                return false;
            }
            ExpressionType nodeType = parent.NodeType;
            if (nodeType <= ExpressionType.Increment)
            {
                if (nodeType != ExpressionType.Decrement && nodeType != ExpressionType.Increment)
                {
                    return NeedsParenthesesPrecedence(parent, child);
                }
            }
            else if (nodeType != ExpressionType.Unbox && nodeType != ExpressionType.IsTrue && nodeType != ExpressionType.IsFalse)
            {
                return NeedsParenthesesPrecedence(parent, child);
            }
            return true;
        }
        
        protected override SqlBuilder Join(BinaryExpression expression, SqlBuilder sqlBuilder)
        {
            Expression2SqlProvider.Join(expression.Left, sqlBuilder);
            int operatorIndex = sqlBuilder.Length;

            Expression2SqlProvider.Join(expression.Right, sqlBuilder);
            int sqlLength = sqlBuilder.Length;

            if (sqlLength - operatorIndex == 5 && sqlBuilder.Sql.EndsWith("null"))
            {
                OperatorParser(expression.NodeType, operatorIndex, sqlBuilder, true);
            }
            else
            {
                OperatorParser(expression.NodeType, operatorIndex, sqlBuilder);
            }

            return sqlBuilder;
        }

        protected override SqlBuilder Where(BinaryExpression expression, SqlBuilder sqlBuilder)
        {
            if (IsNeedsParentheses(expression, expression.Left))
            {
                sqlBuilder += "(";
                Expression2SqlProvider.Where(expression.Left, sqlBuilder);
                sqlBuilder += ")";
            }
            else
            {
                Expression2SqlProvider.Where(expression.Left, sqlBuilder);
            }
            int signIndex = sqlBuilder.Length;

            if (IsNeedsParentheses(expression, expression.Right))
            {
                sqlBuilder += "(";
                Expression2SqlProvider.Where(expression.Right, sqlBuilder);
                sqlBuilder += ")";
            }
            else
            {
                Expression2SqlProvider.Where(expression.Right, sqlBuilder);
            }
            int sqlLength = sqlBuilder.Length;

            if (sqlLength - signIndex == 5 && sqlBuilder.ToString().EndsWith("null"))
            {
                OperatorParser(expression.NodeType, signIndex, sqlBuilder, true);
            }
            else
            {
                OperatorParser(expression.NodeType, signIndex, sqlBuilder);
            }

            return sqlBuilder;
        }
    }
}