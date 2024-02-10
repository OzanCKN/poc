//using PostgresqlGemini.Infrastructure.Outbox;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using PostgresqlGemini.Application.Abstraction.Clock;
//using PostgresqlGemini.Application.Exceptions;
//using PostgresqlGemini.Domain.Abstraction;
//using PostgresqlGemini.Infrastructure.EfConfigurations;

//namespace PostgresqlGemini.Infrastructure;
//public abstract class EntityBaseCKN<t> : entitybaseconfiguration<t>, ientitytypeconfiguration<t> where t : translatableentitybase
//{
//    public new virtual void configure(entitytypebuilder<t> builder)
//    {
//        base.configure(builder);

//        builder.property(e => e.translationkey)
//            .isrequired()
//            .hasmaxlength(255);
//    }
//}