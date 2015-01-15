
Draft specification for object graph for DI/IoC containers testing
------


5 layers View for Model -> Model -> Business -> Data -> Infrastructure

100 wide, 10 for descriptions.

1 of 10 items on each layer is closed generic. Drops containers not support it. .NET code without using this is strange for usual app.

1 of 10 items has no interfaces but registered directly. 

1 of 10 registrations are resolved as lazy objects. Drop containers not supporting these.

1-2 lower layers do not know most of containers (so aboid keys, attribures, reference to container/service locator API). 

1 of 10 items resolves container itself as factory, except last 2 low layers where this count is 0.

1 of 10 resolves factory for specific object.

1 of 10 registrations is keyed, except last 1 low layer where this count is 0. Drops containers not support it. Keys are less antimatters with new C# `nameof(x)`


Low layers has less injections. Top has more injections. 

Alls layers has lateral dependencies. 1 1->1, 1->2

Top layers depend on nearest bottom that far bottom.


Top layers are often resolutions roots. Lower less possibly being roots.

Half of singletons and half of transient.

Top layers have longest type names. Low shorter.

Each objects has 3 properties, 5 methods, 1 event. Really these can be measures.

Each object has necessary attribute. 2 of 10 has any other. Generated graph per framework which works on attributes.

Long names, many attributes and few fields may lead to skew in tests. 
