# Expression2Sql
Expression2Sql是一个可以将Expression表达式树解析成Transact-SQL的开源项目。简单易用，几分钟即可上手使用，因为我在设计Expression2Sql的时候就尽可能的按照Transact-SQL的语法语义风格来设计，只要调用者熟悉基本的Transact-SQL语法即可迅速开码，大大降低了学习Expression2Sql的成本，甚至零成本。对象化操作，链式编程，任意组装sql，参数化赋值，防止sql注入，支持多数据库，生成极度美观的sql字符串(格式化)，优点A，优点B，优点C，优点...还是等你来发现吧！O(∩_∩)O~ Expression2Sql的使用场景主要是用于和第三方的ORM或者是基于ado.net的原生DbHelper帮助类做对接，使其能够支持对象化、表达式树的链式编程
