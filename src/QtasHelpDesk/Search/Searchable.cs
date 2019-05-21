using System.Collections.Generic;
using Lucene.Net.Documents;
using Lucene.Net.Index;
namespace QtasHelpDesk.Search
{
    public abstract class Searchable
    {
        public static readonly Dictionary<Field, string> FieldStrings = new Dictionary<Field, string>
        {
           
            {Field.Href, "Href"},
            {Field.Id, "Id"},
            {Field.Title, "Title"}
        };

        public static readonly Dictionary<Field, string> AnalyzedFields = new Dictionary<Field, string>
        {
         
            {Field.Title, FieldStrings[Field.Title] }
        };

        public abstract string Description { get; }
        public abstract string DescriptionPath { get; }
        public abstract string Href { get; }
        public abstract int Id { get; }
        public abstract string Title { get; }

        public enum Field
        {
       
            Href,
            Id,
            Title
        }

        public IEnumerable<IIndexableField> GetFields()
        {
            return new Lucene.Net.Documents.Field[]
            {
                new TextField(AnalyzedFields[Field.Title], Title, Lucene.Net.Documents.Field.Store.YES){ Boost = 4.0f },
                new StringField(FieldStrings[Field.Id], Id.ToString(), Lucene.Net.Documents.Field.Store.YES),
              //new StringField(FieldStrings[Field.Href], Href, Lucene.Net.Documents.Field.Store.YES)
            };
        }
    }
}
