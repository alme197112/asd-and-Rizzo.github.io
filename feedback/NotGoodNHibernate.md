

- NHibernate makes as complex as possible to outputs SQL and values of parameters, and make things complexier with time. In order to sell NHibernateProfiler I guess.

- NHibernate IEnumerable<>.Contains(x.Prop) failes to generate valid query(in ()), but IEnumerable<>.ToArray().Contains(x.Prop) (in (?,?).

-  SetParameterList("ids", ids.ToList()) works, but not way to set IEnumerable<> with SetParameter or SetParameterList

