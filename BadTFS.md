
TFS
===

[TFS] with Team Foundation Version Control is unintuitive (I used GIT and SVN and was happy), unlogical and not consistent.

Here is list of issues (VS 2012 and TFS 2013):

- On check in it shows that there are merge conflicts even if I do not check in conflicted files. Conflicted file onlu one - MySolution.sln, which I have different local. It becomes different right after VS open for some reason.

- When I create and save query in TFS web UI it gets all data from several TFS "projects & teams", but is located in one "project & team", and I cannot share it accross all TFS. This query about myself (what was done and what is in progress/todo). I want just to visit any TFS part and get my query.

- When I put query in shared I cannot delete it. Shared query Owner is Me, and yet I cannot deleted it. I am the owner and cannot delete.

- Server mode (which is default) when getting sources precludes any changed done outside of VS. TFS just do not see these. I have to change all sources to Local.

- TFS becomes terribly slow if to get 2 branches of sources into 1 workspace. Workspace is created by default and 1. So I have to have new workspace for every branch. I should have several branches in one workspace, but that just buggy.

- TFS has to many fields which are not visible in issue web UI. When they are changed post fact I started to work on issue, I do not get these updates. Need manually revisit different parts from time to time. And I have 32`` monitor, but web UI is for small ones, why I cannot have all info shown?

- I created shelveset to one branch and want to apply to other. I have to go via command line tools while having bloat of UI, which are not installed by default. I am OK with GIT CLI or with SVN *.patch. But in TFS I have to patch things manually by copy/paste.

- TFS requres work item id with check in and resolves item on check in by default until I specify otherwise. Each time I commit test before commit I have to do it.

- TFS has UI where ids I want to send via email are UNCOPYBALE. I have to write down them manually. E.g. review numbers. And my team members ignore event imporant review items until I ping them directly.

If people are OK with it than it indicated bad process of development around.

- TFS was payed for, but takes to much time to workaround, same I do when use open source tools.

- Other issue related to history of check ins, changes made by check-in , work estimates are also unintuitive/broken.

- When I Check in on solution in solution explorer it checkins all files, but when I view history on this, then history is shown only of *.sln file. Experienced first, I expected history of solution will include history of files of this solution either.

[TFS]: https://en.wikipedia.org/wiki/Team_Foundation_Server


