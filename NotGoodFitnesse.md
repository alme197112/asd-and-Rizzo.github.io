

Finesse for .NET is not good overall (Gherkin ecosystem is good).  Next list is of big and small runts on Finesse. 

- It makes multi line enumeration of text suites into single line then failing to see any suites any more.

- It has broken menus in IE preventing working with it. 
 
- ASDSuite will fail to be seen as suite. AsdSuite is OK.

- When class constructor fails  error swallow. When class methods are called next, it tries to calls methods of some other classes out there without valid reason.

- Any errors in called methods are swallowed and test passed. E.g. if setup method `SetXyz` fails you will not know. 

- Pressing `Stop Test` often do not response or hangs. Sometimes `Stop Test` and `Test` are in same windows - this is bug case cannot start run non running tests or cannot stop no running. Sometimes this happens if to kill runner process, but not necessary. But Finesse should be ready for hard kill, e.g. when test execution hangs and person does not want to wait.

- Runner.exe process hangs and prevents rebuild by assemblies lock. Test do not run any new threads or wait handles to make hang happen.

- Also it is possible to automate attachment to runner process externally, but this is still time consuming. So adhoc debug attachment still necessary. Some may argue that debugging in this case not good, but what if `Finesse` pushed on big legacy product which never know what is BDD/TDD?




