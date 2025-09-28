# Complete Database & SQL Interview Topics Checklist

## 📊 **SQL FUNDAMENTALS**

### **1. Basic SQL Operations**
- [ ] SELECT statements
- [ ] WHERE clause conditions
- [ ] ORDER BY (ASC/DESC)
- [ ] DISTINCT keyword
- [ ] LIMIT/TOP clauses
- [ ] Column aliases (AS)
- [ ] Arithmetic operations in SELECT

### **2. SQL Data Types**
- [ ] Numeric types (INT, DECIMAL, FLOAT)
- [ ] Character types (CHAR, VARCHAR, TEXT)
- [ ] Date/Time types (DATE, TIME, DATETIME, TIMESTAMP)
- [ ] Boolean type
- [ ] Binary types (BLOB, BINARY)
- [ ] JSON/XML data types

### **3. Filtering and Sorting**
- [ ] Comparison operators (=, <>, <, >, <=, >=)
- [ ] Logical operators (AND, OR, NOT)
- [ ] BETWEEN operator
- [ ] IN operator
- [ ] LIKE operator with wildcards (%, _)
- [ ] IS NULL / IS NOT NULL
- [ ] CASE statements

## 🔗 **JOINS AND RELATIONSHIPS**

### **4. JOIN Operations**
- [ ] INNER JOIN
- [ ] LEFT OUTER JOIN
- [ ] RIGHT OUTER JOIN
- [ ] FULL OUTER JOIN
- [ ] CROSS JOIN
- [ ] SELF JOIN
- [ ] NATURAL JOIN
- [ ] Understanding JOIN conditions
- [ ] Multiple table JOINs

### **5. Set Operations**
- [ ] UNION
- [ ] UNION ALL
- [ ] INTERSECT
- [ ] EXCEPT/MINUS
- [ ] Differences between set operations

## 📈 **AGGREGATION AND GROUPING**

### **6. Aggregate Functions**
- [ ] COUNT() and COUNT(DISTINCT)
- [ ] SUM()
- [ ] AVG()
- [ ] MIN() and MAX()
- [ ] GROUP_CONCAT() / STRING_AGG()

### **7. GROUP BY Clause**
- [ ] Basic GROUP BY
- [ ] GROUP BY with multiple columns
- [ ] HAVING clause vs WHERE clause
- [ ] Filtering grouped results
- [ ] GROUP BY with expressions

### **8. Advanced Aggregation**
- [ ] ROLLUP
- [ ] CUBE
- [ ] GROUPING SETS
- [ ] Filtered aggregates

## 🔍 **SUBQUERIES AND DERIVED TABLES**

### **9. Subquery Types**
- [ ] Scalar subqueries
- [ ] Correlated subqueries
- [ ] Non-correlated subqueries
- [ ] EXISTS/NOT EXISTS
- [ ] IN/NOT IN with subqueries
- [ ] ANY/SOME/ALL operators

### **10. Common Table Expressions (CTEs)**
- [ ] Basic CTE syntax
- [ ] Multiple CTEs in single query
- [ ] Recursive CTEs
- [ ] CTEs for complex queries
- [ ] CTE performance considerations

## 🏗️ **DATABASE DESIGN AND NORMALIZATION**

### **11. Database Normalization**
- [ ] First Normal Form (1NF)
- [ ] Second Normal Form (2NF)
- [ ] Third Normal Form (3NF)
- [ ] Boyce-Codd Normal Form (BCNF)
- [ ] When to denormalize
- [ ] Trade-offs of normalization

### **12. Keys and Constraints**
- [ ] Primary Key
- [ ] Foreign Key
- [ ] Unique Key
- [ ] Composite Keys
- [ ] Candidate Keys
- [ ] Surrogate vs Natural Keys
- [ ] NOT NULL constraints
- [ ] CHECK constraints
- [ ] DEFAULT values

### **13. Relationships**
- [ ] One-to-One relationships
- [ ] One-to-Many relationships
- [ ] Many-to-Many relationships
- [ ] Implementing relationships with foreign keys
- [ ] Relationship cardinality

## ⚡ **PERFORMANCE AND OPTIMIZATION**

### **14. Indexing**
- [ ] Clustered indexes
- [ ] Non-clustered indexes
- [ ] Composite indexes
- [ ] Covering indexes
- [ ] Unique indexes
- [ ] Filtered indexes
- [ ] Index maintenance
- [ ] When to create indexes
- [ ] Index selection and usage

### **15. Query Optimization**
- [ ] EXPLAIN / Execution plans
- [ ] Query profiling
- [ ] Avoiding SELECT *
- [ ] Proper WHERE clause usage
- [ ] JOIN optimization
- [ ] Subquery vs JOIN performance
- [ ] Temporary tables vs CTEs

### **16. Performance Concepts**
- [ ] Table scanning
- [ ] Index seeking
- [ ] Bookmark lookups
- [ ] Statistics
- [ ] Parameter sniffing
- [ ] Query hints

## 📝 **DATA MODIFICATION**

### **17. DML Operations**
- [ ] INSERT statements
- [ ] UPDATE statements
- [ ] DELETE statements
- [ ] MERGE/UPSERT operations
- [ ] TRUNCATE vs DELETE
- [ ] Bulk insert operations

### **18. Transactions**
- [ ] BEGIN TRANSACTION
- [ ] COMMIT
- [ ] ROLLBACK
- [ ] SAVEPOINT
- [ ] ACID properties
- [ ] Transaction isolation levels
- [ ] Deadlocks and prevention

## 🏪 **ADVANCED SQL FEATURES**

### **19. Window Functions**
- [ ] ROW_NUMBER()
- [ ] RANK() and DENSE_RANK()
- [ ] NTILE()
- [ ] LAG() and LEAD()
- [ ] FIRST_VALUE() and LAST_VALUE()
- [ ] PARTITION BY clause
- [ ] ORDER BY in window functions
- [ ] Frame clauses (ROWS, RANGE)

### **20. Analytical Functions**
- [ ] Running totals
- [ ] Moving averages
- [ ] Year-over-year growth
- [ ] Cumulative sums
- [ ] Percentage of total

### **21. String and Date Functions**
- [ ] String concatenation
- [ ] Substring operations
- [ ] Pattern matching
- [ ] Date arithmetic
- [ ] Date formatting
- [ ] Date extraction functions

## 🗄️ **DATABASE OBJECTS**

### **22. Stored Procedures**
- [ ] Creating and executing procedures
- [ ] Parameters (IN, OUT, INOUT)
- [ ] Error handling in procedures
- [ ] Benefits of stored procedures

### **23. Functions**
- [ ] Scalar functions
- [ ] Table-valued functions
- [ ] Deterministic vs non-deterministic
- [ ] Built-in functions usage

### **24. Views**
- [ ] Simple views
- [ ] Complex views
- [ ] Materialized views
- [ ] Updatable views
- [ ] View performance considerations

### **25. Triggers**
- [ ] AFTER triggers
- [ ] INSTEAD OF triggers
- [ ] Trigger execution order
- [ ] Use cases for triggers

## 🔐 **SECURITY AND ADMINISTRATION**

### **26. Database Security**
- [ ] User management
- [ ] Role-based permissions
- [ ] GRANT and REVOKE
- [ ] Schema permissions
- [ ] SQL injection prevention

### **27. Backup and Recovery**
- [ ] Backup types (full, differential, transaction log)
- [ ] Recovery models
- [ ] Point-in-time recovery

## 📚 **SQL VARIATIONS AND STANDARDS**

### **28. Dialect Differences**
- [ ] MySQL vs PostgreSQL vs SQL Server
- [ ] Oracle vs other databases
- [ ] SQL standard compliance
- [ ] Common extensions

## 🎯 **PRACTICAL SCENARIOS**

### **29. Common Business Problems**
- [ ] Finding duplicates
- [ ] Gap analysis
- [ ] Hierarchical data (employee org charts)
- [ ] Running totals and cumulative sums
- [ ] Pivot queries
- [ ] Top N per group queries

### **30. Complex Query Patterns**
- [ ] Recursive queries for hierarchies
- [ ] Correlated subqueries for existence checks
- [ ] Multiple aggregation levels
- [ ] Conditional aggregation
- [ ] Sequential data analysis

## 🧪 **INTERVIEW-SPECIFIC TOPICS**

### **31. Frequently Asked Concepts**
- [ ] Difference between WHERE and HAVING
- [ ] INNER JOIN vs LEFT JOIN use cases
- [ ] UNION vs UNION ALL performance
- [ ] EXISTS vs IN performance
- [ ] CTEs vs temporary tables
- [ ] Index usage scenarios

### **32. Problem-Solving Patterns**
- [ ] Generating number sequences
- [ ] Finding nth highest values
- [ ] Calculating running totals
- [ ] Identifying gaps in sequences
- [ ] Hierarchical data queries
- [ ] Pivoting data

## 📖 **MISSING BUT IMPORTANT TOPICS**

### **33. Advanced Database Concepts**
- [ ] Database partitioning
- [ ] Sharding strategies
- [ ] Replication concepts
- [ ] Full-text search
- [ ] Spatial data and queries
- [ ] JSON/XML querying

### **34. Modern SQL Features**
- [ ] Lateral joins
- [ ] Filtered indexes
- [ ] Window function frames
- [ ] Common table expressions with updates
- [ ] MERGE statements

### **35. Database Design Patterns**
- [ ] Star schema vs Snowflake schema
- [ ] Fact and dimension tables
- [ ] Slowly Changing Dimensions (SCD)
- [ ] Data warehouse concepts

This comprehensive checklist covers 100% of SQL and database topics you've been asked about, plus critical areas that frequently appear in interviews but weren't covered in your specific sessions.
