
TFS
===

[TFS] with Team Foundation Version Control is unintuitive (I used GIT and SVN and was happy), illogical, not consistent, buggy, slow.

There are hate articles of TFS in internet.  

And this is my  list of issues (VS 2012/2013 and TFS 2010/2013, with personal preferences for Git and open source tools, and experience with Atlassian, and different very old enterprise tools):

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

- When I Check in on solution in solution explorer it checkins all files, but when I view history on this, then history is shown only of `*.sln` file. Experienced first, I expected history of solution will include history of files of this solution either.

- I have huge monitor, but [opened links numbers](NotGoodTfs_1.png) are truncated and columns not expandable, with huge amount of white space without any info around. I need these numbers to associate check-ins with work or communicate.

- There is one item associated while puting code onto server, but it [has 2 different comboboxes](NotGoodTfs_2.png) to be manipulated. With right click and left click on different place. This misleads and requires to research menu needed.

- My Outlook is in 24 hours format, but TFS site in AM/PM.
I cannot (change site without changing language)(NotGoodTfs_3.png), there are only few language choices non of them suites me - need English with 24 hour format.
I have to translate this formats when working with Outlook messages and TFS items/history.

- TFS merge is stupid. Tortoise Merge and WinMerge merged what  TFS fails with ease.

- I can revert all revision up to some locally via "Get this revision", but I cannot revert some revision between cause "Rollback this revesion" changed server side, not local.

- In backlog view Chrome sometimes fails to find or navigate to item via Ctrl+F of title. `Search work items` does not search via title. And page does not contains build in filter,  have to copy and modify full blown query for search via title. "Collapse all" may help to find items if fit into page(but not linked sub items), but who knows beforehand that Ctrl+F fails. I would blame Chrome if page contain easy build in search, but there is no and Ctrl+F should work in all supported browsers.

- On check in I got in one control next messages one after another:
```
 (red exclamation) Collection was modified; enumeration operation may not execute.
 Changeset 123 successfully checked in.
 ```
 
 - I changed Windows Domain password while VS was opened on TFS project. VS shown popup with TFS needs password. I clicked mouse and pressed any case - new window and VS were hang. Killed VS.
 
 - TFS is slow. Freqyently it langs hangs and freeze user interface of Vistual Studio. Same for external tools.  Undo is very slow.
 
 - Cancel on commit leads to weird errors needed to reconstucte commit. 
 
 - In issue view TFS VS I have buttons to open in Office. But now button to open in web browser or to copy full issue name (id + title) to share this in communication.
 
- tf.exe does not allows to create second workspace targeting same TFS collections. I need this because if I map several branches onto local folders VS becomes very very slow on any operation with version control. And there is no official Nuget TFS client assemblies to automate TFS via .NET language easily.

- There is no means to copy old code in Diff if it intermingles with new.

- TFS is integerated into shell, but has no icon. Git and Svn has - so easy to find menu entry.

- We have team. They create many shelvesets and submit these to reviewer in other team, creating big unmergable big ball of mood. Shelveset hell. In git we do fork for team with several branches for features team works. Commits and pushes are done, back merges from mainline. When it time to review by external team these are given branch with cohesive already merged feature.

- I made map from `VisualStudio.com` to `Local` in VS 2013. Added files in `Windows Explorer`. `Team Explorer` does not see my chabes. But this uses to work on previous project.

- when I do somthing in TFS Compare, and operation fails, and nothing changes. I still does long compare operation again. Even if single change is made, whole process reruns for all files at hands which is long.

- My solution went `Offline`. I have not noticed this. When I pressed `get latest` version in source explorer there was no indication that I am Offline. I did not get new code even after pressed `get latest`. So `offline` is perverted notion in VS, I am really online and loged into TFS, but formally offline.

- TFPT Undo dialog has no ways to sort by file extension. I need this to undo code, but not locally changed config.

- TFPT Undo dialog there is not Compare button to decide inline if I do want or dot not want Undo this file among many.

- some times TFS kind of hangs downloading single file, but in reality it started to download other without updating progress window. Both via Explorer menu and in VS.

- Developer put 1.5 GB binary file into solution into sub folder, I want to skip update it, but update all other folders and files. There is not way to get all updates skipping one folder if select all files+folders and deselect one in Windows Explorer. Only update several dozens folder+files one by one or manually deselect temp build folders and pure files got in select. I hoped Get all to work even if one selected item is TFS mapped, even of others no. I work remotely far away via VPN, so downloading such big goes to timeout.

- TFS via Windows Explorer does not matched TFS in VS does not matches command line, etc.

- Given one big file to update, TFS download does not shows how much was downloaded.

- TFS marks files as read only preventing other more convenient and useful tools to work on these.

- I tried to change file and get error that TFS server not avalable. Admin prevented to choose Local setting duriing maping, only server.  I pressed Disconnect from TFS, and VS go blank. I restarted TFS to go Offline. It notified that sever is not available and suggested offline. I pressed go. So Disconnect button is sense cause I still need to restart VS.

```
---------------------------
Microsoft Visual Studio
---------------------------
Error
TF400324: Team Foundation services are not available from server tfsnpt.int.thomson.com\Cobalt_Collection.
Technical information (for administrator):
  The remote name could not be resolved: 'tfsnpt.int.thomson.com'
---------------------------
OK   
---------------------------
```

- If want put bug into `ready to test` but there no such option. Only when I assign bug to myself I can see this options. What I want is to see all possible states with explanation how to get into these. 
It may be if I fixed bug as part of other bug. Tested that current bug fixed either, and I not used any time into this bug except testing, so it was not assigned to me.

- TFS searches and shares shelves only if you type user name EXACTLY, you cannot search by shelveste name.

[TFS]: https://en.wikipedia.org/wiki/Team_Foundation_Server


