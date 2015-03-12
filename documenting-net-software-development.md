How to write docs while developing .NET software 
===

If you write good Code you write good Docs. If you write bad Docs you write bad Code. If you write bad Code you write bad Docs.

Context
---

- There is no usual paper. 
- All things digital. Paper Docs are dead.
- Economically efficient are open, transparent, crowd sourced and continious processes. 
- Open/transparent/crowd sourced inside Enterprise or/and outside. 
- Other kind of processes are efficient in very rare cases.


What
---

-Docs and Code are Digital Artifacts.
-Docs includes Code.
-Executable Code is executable Docs.
-Docs consist of symbols and images.
-Code consist of symbols.
-Symbols are organized into higher level structures.

Properties
---

Documentation has similar proprieties as executable Code text.

**Searchable**

Target audience can find symbols via search engine.

Not searchable Docs = Not existing Docs. Total waste.

*Bad:*

-Not indexed enterprise Software Control Management with *.doc files in it is waste. E.g. container.doc files commited into SVN not indexed by Elastic Search.

- Not indexed email communication regarding requirements or design is waste. E.g. 3 email threads about the same thing instead 1.

- CHM file uploaded into indexed location with not support for CHM, CHM to PDF conversion should be done.

*Good:*

- Enterprise collaboration network or wiki

- Public internet source repositories and public conversation threads


**Linked**

Each Doc links with `See also` and reference and tags and catetorirs to other Docs. Documents are piecemeal.

*Good examples:*

- Wikipedia

- This book [7]. It links to itself, to other books. Exercises also link to creators of exercises. Source of book available in TeX files linked to each other.
Bad examples:

- Docs authored in long Word documents with all in one with friction full approach to updates and doc refactoring

- Most conventional paper oriented books.

- All books without free online versions because you cannot freely link into them inside your Docs for other to read.


**Always usable without "ToDo" noise**

- No TBD (to be done), no ToDo in text. All such things replaced with one sentence maximally representing what should be unfolded when whole doc is written. Instead of TBD/ToDo phrase which allows guessing intent and makes doc to be always ready.

- Never DRAFT. Also can be marked DRAFT, but still valuable and valid.[1]

**Evolutionary**
- Good doc starts from few lines of facts which written in 5 minutes but give much more of time saving for others. Then this facts are elaborated, surrounded with definitions, examples, spitted into several docs.

**Maintainable**

Any person can change and generate output of docs, with all revisions traceable. `Change` means no need to request rights to edit document, but editing will create fork of document with possibility to do merge changes back in main one.

*Bad examples:*

- Using proprietary software for drawing diagrams when use is not well grounded. This may prevent other people who have no this software from editing and viewing diagrams. May prevent from having Continuous Deployment sever from generating diagram images as part of build process.

- Some kind of Wiki with friction full way of getting rights for its usage and or modification.
Good examples:

- Free diagramming software which suits needs to describe semantics event if it has not beautiful styles to pretty print.

- Using Markdown or TeX text files committed into GIT sever with generation of published HTML or 
PDF as part of build process.

- Latest C++ standard in GitHub in TeX form.

**Question oriented **

If somebody going to ask highly anticipated question via private email or chat - write answer beforehand into searchable location. Convert questions and answers in private communication into part of documents.

**Targeted**
Use views and place views into place people habitat . Think of other people and write for them accordingly [4][5]

- QA or Support oriented docs should not different content then Developers, may be overlapping 20% of info, but common parts produced as separate linked documents.

**Right place**

Search place where docs will be most visible. 

Write docs into code, instead of docs when possible.[2][3] Put documented interface of code as docs into public.

Write from outer goals to inner specificaiton[17] and vice versa[18].

*Bad examples:*

- Docs are not with code where most value would be provided. E.g. in `IShortcut.cs`:

```charp
/// <summary>
///  Invokes shortcut
/// </summary>
void Invoke();
```

Code contains crap shown to all developers in IDE.

And then somewhere into docs in some `*.docx` put into version control system:
```charp
IShortcut.Invoke()    - Method invoked when user presses keyboard combination assigned to this shortcut.
```

- `System.Diagnostics.TraceSource` related stuff is good. But it hard to grasp all what/how/why of it without good guiding entering document.

**Goal/Intention/Action oriented with What/How/Why separations**

- When I want to do something I search What can be used  - list of features and high level aspects.

- Then I want to do something quick to try via How.

- Then I rise questions or need clarification in Why.

- Steps can go any order, I have to be sure for ability to enter from any Doc cause there are several Linked docs different for What/How/Why.


**2 and more levels of documentation**

Source code should not only written self descritive, but its should be documented yet enother time via:

- semantically meaningful documentation to code functions

- static dependecny stucture revealed by analysys tools for static type langauges

- unit test or integration tests

*Examples*

- E.g. script file doing some simple job to automated deployment process is bad. Each such script file should contain header with description of why and what script does. Such scripts are not target for static dependecy analisys or automated testing.

 

**Simple/Complex or 20/80 separation**

- Write down 20 of info about simple things, skip complex things until asked and write down into separate Doc.

**Drawing clarified**

- Diagrams may lead to ambiguity not clear without context. Write down exact step by step text what happens on diagram. Restate exactly the same via pretty picture. Not all in one, but several diagrams for different aspects.

**Executable if possible**

- Unit tests, unit tests as Koans,  Automated Acceptance in Gherkin are preferred to other Docs, because this are not only docs but quality assurance of behavior and APIs.[6][15]

**Defined retention policy**

If docs are just deleted after some time, this is bad.

*Bad example:*

-Much of docs stored in Issue Tracking system. Issue tracking is not scalable or used in not scalable way. Administrators just delete tail older then 1 year.

*Good:*

- Collaboration system has archive button, doc is marked archived. Its fetching optimized.

**Symbols naming and organization**

Good names of classes, methods, namespaces and packages(assemblies) are the easiest means to ensure some documentations presented. Including hierarchical organization and structuring of namings. E.g. MyCompany.MyProduct.MyFeature.MyLayer. [11] [12]

Choosing names are kind of TDD. TDD  improves code and adds executable documentations. Naming improves code navigation and sustainability of cohesion.

**Abbreviations and contractions.**

Meanings of these must be searchable or well known by all.

Not used as optimization until other options not evaluated.

See also [10].

*Good:*

- Optimize XML not by renaming MySymbol to MS, but via other options.  Try to reorganize XML structure. E.g. make MySymbol  attribute instead of element or reduce number of times MySymbol  is repeated by splitting out addition XML document sub part. Try to use binary serialization.

- If still need to go with XML and replacing MySymbol  with MS, then do this declaratively, e.g. providing explicit dictionary which maps  MS <-> MySymbol.

*Bad:*

- Contractions not documented.

- Contractions provided instead of hierarchical context optimization. E.g. FwkWfsProcess instead of Framework.Workflows.Process.

- Several different contractions. ProcessItemId is not contracted in one place, contracted to ProcItemId in another and to PIID in third one.[10]

**Right tools**
Choose right language and tool to put something into mind of reader. There are tools for:

- mind [9] and concept mapping[8] [13]

- collaborative Wiki and ideas discussion

- version control systems

- diagramming

- track roles, depedencies and times[16]

- web bookmarking and lists

- zooming presentations [8]

- structure organization of you code to be tool able regarding documentation[14]

- document authoring, revision and collaboration tool (e.g. git based text editing with web view)

- good document authoring language

[1]: http://www.agilemodeling.com/essays/agileDocumentation.htm
[2]: http://www.icsharpcode.net/TechNotes/Commenting20020413.pdf
[3]: http://www.icsharpcode.net/TechNotes/TechnicalWriting20020325.pdf
[4]: http://www.cs.ubc.ca/~gregor/teaching/papers/4+1view-architecture.pdf
[5]: http://en.wikipedia.org/wiki/Enterprise_architecture_framework ("enterprise" here can be replaced with "open")
[6]: http://dannorth.net/introducing-bdd/
[7]: http://joshua.smcvt.edu/linearalgebra/book.pdf
[8]: http://vue.tufts.edu/
[9]: http://freemind.sourceforge.net/
[10]: http://msdn.microsoft.com/en-us/library/ms229045.aspx
[11]: http://refcardz.dzone.com/refcardz/designing-quality-software
[12]: http://msdn.microsoft.com/en-us/library/ms229026.aspx
[13]: http://cmap.ihmc.us/publications/researchpapers/theorycmaps/theoryunderlyingconceptmaps.htm
[14]: https://github.com/fsprojects/ProjectScaffold
[15]: http://dannorth.net/whats-in-a-story/
[16]: http://www.projectlibre.org/
[17]: http://www.infoq.com/news/2015/02/introducing-bdd
[18]: http://www.infoq.com/minibooks/domain-driven-design-quickly
