## SuperExpression

This repo is designed to create a concise guide about dynamic Expression Trees to compare performance in use cases where performance is crucial for making decisions, In case of good results it can be used as a library to pre-build expressions, storing in the memory for further use. 

--- 

### 1. Dictionaries vs Expressions

#### Target
Check if we can compile code dynamically through configuration or dynamic setup and obtain better performance than a dictionary.

#### Case
190 cases from-to 
string->string, one->one.

Stored on setup:
- pre-built (dictionary and concurrent dictionary) with all cases;
- pre-build and compile expression dynamically.
- hard-coded switch case with the same keys and values.

#### Result (Benchmark - Release)
| Method                              | Mean     | Error     | StdDev    |
|-------------------------------------|---------:|----------:|----------:|
| DiscoveryByDictionary               | 4.691 us | 0.0101 us | 0.0089 us |
| DiscoveryByConcurrentDictionary     | 4.798 us | 0.0060 us | 0.0050 us |
| DiscoveryBySwitchCaseExpressionTree | 7.741 us | 0.0174 us | 0.0163 us |
| DiscoveryBySwitchCaseHardCoded      | 3.745 us | 0.0107 us | 0.0100 us |

#### Conclusion
1. Switch case (hard-coded) performed better than dictionaries for 190 cases;
2. Switch case by expression tree is not that efficient as it seems for 190 cases;
3. For flexible setup, Dictionary / ConcurrentDictionary will perform better than pre-build the expression tree for 190 cases;

#### Image:
![Alt text](https://prnt.sc/CR-uHm8UeBOI "switch case expression tree detailed.")
---

### Next steps
- [ ] Check performance with fewer cases amount.