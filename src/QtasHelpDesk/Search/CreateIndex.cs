using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Util;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Queries.Mlt;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Microsoft.AspNetCore.Hosting;
using QtasHelpDesk.ViewModels.Content;


public   class CreateIndex
{

    static readonly Lucene.Net.Util.LuceneVersion _version = Lucene.Net.Util.LuceneVersion.LUCENE_48;
    private readonly IndexSearcher _searcher;
    private readonly IHostingEnvironment _hostingEnvironment;

    public CreateIndex(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        _searcher = new IndexSearcher(
            DirectoryReader.Open(FSDirectory.Open(_hostingEnvironment.WebRootPath + @"\idx")));
    }


    public static Document MapPostToDocument(PostViewModel post)
    {
        var postDocument = new Document();
        postDocument.Add(new Field("Id", post.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
        var titleField = new Field("Title", post.Title, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
        titleField.Boost = 3;
        postDocument.Add(titleField);
        postDocument.Add(new Field("Summary", post.Summary, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
        return postDocument;
    }

    public  void CreateFullTextIndex(List<PostViewModel> dataList)
    {
        TextReader stopWords = new StringReader("به");
        ISet<string> stopWord = new HashSet<string>();
        stopWord.Add("از");
        stopWord.Add("به");
        stopWord.Add("با");
        stopWord.Add("تا");
        stopWord.Add("و");
        stopWord.Add("است");
        stopWord.Add("هست");
        stopWord.Add("هستیم");
        stopWord.Add("هستید");
        stopWord.Add("هستند");
        stopWord.Add("نیست");
        stopWord.Add("نیستیم");
        stopWord.Add("نیستید");
        stopWord.Add("نیستند");
        stopWord.Add("اما");
        stopWord.Add("آیا");
        stopWord.Add("یا");
        stopWord.Add("آن");
        stopWord.Add("اینجا");
        stopWord.Add("آنجا");
        stopWord.Add("بود");
        stopWord.Add("باد");
        stopWord.Add("برای");
        stopWord.Add("که");
        stopWord.Add("دارم");
        stopWord.Add("داری");
        stopWord.Add("دارد");
        stopWord.Add("داریم");
        stopWord.Add("دارید");
        stopWord.Add("دارید");
        stopWord.Add("دارند");
        stopWord.Add("چند");
        stopWord.Add("را");
        stopWord.Add("ها");
        stopWord.Add("های");
        stopWord.Add("هم");
        stopWord.Add("می");
        stopWord.Add("در");
        stopWord.Add("باشم");
        stopWord.Add("باشی");
        stopWord.Add("باشد");
        stopWord.Add("باشیم");
        stopWord.Add("باشید");
        stopWord.Add("باشند");
        stopWord.Add("اگر");
        stopWord.Add("مگر");
        stopWord.Add("بجز");
        stopWord.Add("جز");
        stopWord.Add("الا");
        stopWord.Add("اینکه");
        stopWord.Add("چرا");
        stopWord.Add("کی");
        stopWord.Add("چطور");
        stopWord.Add("چی");
        stopWord.Add("چیست");
        stopWord.Add("چنین");
        stopWord.Add("اینچنین");
        stopWord.Add("نخست");
        stopWord.Add("اول");
        stopWord.Add("آخر");
        stopWord.Add("ابتدا");
        stopWord.Add("انتها");
        stopWord.Add("صد");
        stopWord.Add("هزار");
        stopWord.Add("میلیون");
        stopWord.Add("ملیارد");
        stopWord.Add("میلیارد");
        stopWord.Add("تریلیون");
        stopWord.Add("تریلیارد");
        stopWord.Add("میان");
        stopWord.Add("بین");
        stopWord.Add("زیر");
        stopWord.Add("بیش");
        stopWord.Add("روی");
        stopWord.Add("ضمن");
        stopWord.Add("همانا");
        stopWord.Add("ای");
        stopWord.Add("بعد");
        stopWord.Add("پس");
        stopWord.Add("قبل");
        stopWord.Add("پیش");
        stopWord.Add("هیچ");
        stopWord.Add("همه");
        stopWord.Add("واما");
        stopWord.Add("شد");
        stopWord.Add("شدم");
        stopWord.Add("شدی");
        stopWord.Add("شدیم");
        stopWord.Add("شدند");
        stopWord.Add("یک");
        stopWord.Add("یکی");
        stopWord.Add("بود");
        stopWord.Add("نبود");
        stopWord.Add("میکند");
        stopWord.Add("میکنی");
        stopWord.Add("میکنیم");
        stopWord.Add("میکنید");
        stopWord.Add("میکنند");
        stopWord.Add("طور");
        stopWord.Add("اینطور");
        stopWord.Add("آنطور");
        stopWord.Add("هر");
        stopWord.Add("حال");
        stopWord.Add("مثل");
        stopWord.Add("خواهم");
        stopWord.Add("خواهی");
        stopWord.Add("خواهد");
        stopWord.Add("خواهیم");
        stopWord.Add("خواهند");
        stopWord.Add("خواهیم");
        stopWord.Add("داشته");
        stopWord.Add("داشت");
        stopWord.Add("داشتی");
        stopWord.Add("داشتم");
        stopWord.Add("داشتید");
        stopWord.Add("داشتیم");
        stopWord.Add("داشتند");
        stopWord.Add("آنکه");
        stopWord.Add("مورد");
        stopWord.Add("کنم");
        stopWord.Add("کنی");
        stopWord.Add("نکنم");
        stopWord.Add("نکنی");
        stopWord.Add("نکند");
        stopWord.Add("نکنیم");
        stopWord.Add("نکنید");
        stopWord.Add("نکنند");
        stopWord.Add("نکن");
        stopWord.Add("بگو");
        stopWord.Add("نگو");
        stopWord.Add("مگو");
        stopWord.Add("بنابراین");
        stopWord.Add("بدین");
        stopWord.Add("من");
        stopWord.Add("تو");
        stopWord.Add("او");
        stopWord.Add("شما");
        stopWord.Add("ایشان");
        stopWord.Add("ی");
        stopWord.Add("-");
        stopWord.Add("های");
        stopWord.Add("خیلی");
        stopWord.Add("بسیار");
        var directory = FSDirectory.Open(new DirectoryInfo(_hostingEnvironment.WebRootPath + @"\idx"));
        var analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48, stopWords);
        using (var writer = new IndexWriter(directory, new IndexWriterConfig(LuceneVersion.LUCENE_48, analyzer)))
        {
            foreach (var news in dataList)
            {
                writer.AddDocument(MapPostToDocument(news));
            }


            writer.Commit();

        }
    }
    private  int GetLuceneDocumentNumber(int postId)
    {
        var analyzer = new StandardAnalyzer(_version);
        var parser = new QueryParser(_version, "ID", analyzer);
        var query = parser.Parse(postId.ToString());
        var doc = _searcher.Search(query, 1);
        if (doc.TotalHits == 0)
        {
            return 0;
        }
        return doc.ScoreDocs[0].Doc;
    }
    public  Query CreateMoreLikeThisQuery(int postId)
    {
        var docNum = GetLuceneDocumentNumber(postId);
        if (docNum == 0)
            return null;

        var analyzer = new StandardAnalyzer(_version);
        var reader = _searcher.IndexReader;

        var moreLikeThis = new MoreLikeThis(reader);
        moreLikeThis.Analyzer = analyzer;
        // moreLikeThis.SetFieldNames(new[] { "Title", "Body" });
        moreLikeThis.MinDocFreq = 1;
        moreLikeThis.MinTermFreq = 1;
        //moreLikeThis.Boost = true;

        return moreLikeThis.Like(docNum);
    }
    public  string ShowMoreLikeThisPostItems(int postId)
    {
        string result = null;
        var query = CreateMoreLikeThisQuery(postId);
        if (query == null)
            return string.Empty;

        var hits = _searcher.Search(query, n: 5);

        result += "<ul class='Tab-items'>";


        foreach (var item in hits.ScoreDocs)
        {

            var doc = _searcher.Doc(item.Doc);
            var id = doc.Get("ID");
            if (!postId.ToString().Equals(id))
            {
                var title = doc.Get("Title");
                //  result += "<li> <a  href='/ShowPages.aspx?PageName=ShowNews&NewsID=" + Encryption.Encrypt(id) + "' target='blank'>";
                result += title;
                result += "</a>";
                result += "</li>";
            }


        }
        result += "</ul>";
        return result;
    }

    public  void AddIndex(PostViewModel post)
    {
        TextReader stopWords = new StringReader("به");
        ISet<string> stopWord = new HashSet<string>();

        stopWord.Add("از");
        stopWord.Add("به");
        stopWord.Add("با");
        stopWord.Add("تا");
        stopWord.Add("و");
        stopWord.Add("است");
        stopWord.Add("هست");
        stopWord.Add("هستیم");
        stopWord.Add("هستید");
        stopWord.Add("هستند");
        stopWord.Add("نیست");
        stopWord.Add("نیستیم");
        stopWord.Add("نیستید");
        stopWord.Add("نیستند");
        stopWord.Add("اما");
        stopWord.Add("آیا");
        stopWord.Add("یا");
        stopWord.Add("آن");
        stopWord.Add("اینجا");
        stopWord.Add("آنجا");
        stopWord.Add("بود");
        stopWord.Add("باد");
        stopWord.Add("برای");
        stopWord.Add("که");
        stopWord.Add("دارم");
        stopWord.Add("داری");
        stopWord.Add("دارد");
        stopWord.Add("داریم");
        stopWord.Add("دارید");
        stopWord.Add("دارید");
        stopWord.Add("دارند");
        stopWord.Add("چند");
        stopWord.Add("را");
        stopWord.Add("ها");
        stopWord.Add("های");
        stopWord.Add("هم");
        stopWord.Add("می");
        stopWord.Add("در");
        stopWord.Add("باشم");
        stopWord.Add("باشی");
        stopWord.Add("باشد");
        stopWord.Add("باشیم");
        stopWord.Add("باشید");
        stopWord.Add("باشند");
        stopWord.Add("اگر");
        stopWord.Add("مگر");
        stopWord.Add("بجز");
        stopWord.Add("جز");
        stopWord.Add("الا");
        stopWord.Add("اینکه");
        stopWord.Add("چرا");
        stopWord.Add("کی");
        stopWord.Add("چطور");
        stopWord.Add("چی");
        stopWord.Add("چیست");
        stopWord.Add("چنین");
        stopWord.Add("اینچنین");
        stopWord.Add("نخست");
        stopWord.Add("اول");
        stopWord.Add("آخر");
        stopWord.Add("ابتدا");
        stopWord.Add("انتها");
        stopWord.Add("صد");
        stopWord.Add("هزار");
        stopWord.Add("میلیون");
        stopWord.Add("ملیارد");
        stopWord.Add("میلیارد");
        stopWord.Add("تریلیون");
        stopWord.Add("تریلیارد");
        stopWord.Add("میان");
        stopWord.Add("بین");
        stopWord.Add("زیر");
        stopWord.Add("بیش");
        stopWord.Add("روی");
        stopWord.Add("ضمن");
        stopWord.Add("همانا");
        stopWord.Add("ای");
        stopWord.Add("بعد");
        stopWord.Add("پس");
        stopWord.Add("قبل");
        stopWord.Add("پیش");
        stopWord.Add("هیچ");
        stopWord.Add("همه");
        stopWord.Add("واما");
        stopWord.Add("شد");
        stopWord.Add("شدم");
        stopWord.Add("شدی");
        stopWord.Add("شدیم");
        stopWord.Add("شدند");
        stopWord.Add("یک");
        stopWord.Add("یکی");
        stopWord.Add("بود");
        stopWord.Add("نبود");
        stopWord.Add("میکند");
        stopWord.Add("میکنی");
        stopWord.Add("میکنیم");
        stopWord.Add("میکنید");
        stopWord.Add("میکنند");
        stopWord.Add("طور");
        stopWord.Add("اینطور");
        stopWord.Add("آنطور");
        stopWord.Add("هر");
        stopWord.Add("حال");
        stopWord.Add("مثل");
        stopWord.Add("خواهم");
        stopWord.Add("خواهی");
        stopWord.Add("خواهد");
        stopWord.Add("خواهیم");
        stopWord.Add("خواهند");
        stopWord.Add("خواهیم");
        stopWord.Add("داشته");
        stopWord.Add("داشت");
        stopWord.Add("داشتی");
        stopWord.Add("داشتم");
        stopWord.Add("داشتید");
        stopWord.Add("داشتیم");
        stopWord.Add("داشتند");
        stopWord.Add("آنکه");
        stopWord.Add("مورد");
        stopWord.Add("کنم");
        stopWord.Add("کنی");
        stopWord.Add("نکنم");
        stopWord.Add("نکنی");
        stopWord.Add("نکند");
        stopWord.Add("نکنیم");
        stopWord.Add("نکنید");
        stopWord.Add("نکنند");
        stopWord.Add("نکن");
        stopWord.Add("بگو");
        stopWord.Add("نگو");
        stopWord.Add("مگو");
        stopWord.Add("بنابراین");
        stopWord.Add("بدین");
        stopWord.Add("من");
        stopWord.Add("تو");
        stopWord.Add("او");
        stopWord.Add("شما");
        stopWord.Add("ایشان");
        stopWord.Add("ی");
        stopWord.Add("-");
        stopWord.Add("های");
        stopWord.Add("خیلی");
        stopWord.Add("بسیار");
        var directory = FSDirectory.Open(new DirectoryInfo(_hostingEnvironment.WebRootPath + @"\idx"));
        var analyzer = new StandardAnalyzer(_version, new CharArraySet(_version, 0, false));
        var config = new IndexWriterConfig(_version, analyzer);
        using (var indexWriter = new IndexWriter(directory, config))
        {

            var newDoc = MapPostToDocument(post);
            indexWriter.AddDocument(newDoc);
            indexWriter.Commit();
            //indexWriter.Close();
            //directory.Close();
        }
    }
    public  void UpdateIndex(PostViewModel post)
    {
        var directory = FSDirectory.Open(new DirectoryInfo(_hostingEnvironment.WebRootPath + @"\idx"));
        var analyzer = new StandardAnalyzer(_version, new CharArraySet(_version, 0, false));
        var config = new IndexWriterConfig(_version, analyzer);
        using (var indexWriter = new IndexWriter(directory, config))
        {
            var newDoc = MapPostToDocument(post);

            indexWriter.UpdateDocument(new Term("Id", post.Id.ToString()), newDoc);
            indexWriter.Commit();
            //indexWriter.Close();
            //directory.Close();
        }
    }
    public  void DeleteIndex(PostViewModel post)
    {
        var directory = FSDirectory.Open(new DirectoryInfo(_hostingEnvironment.WebRootPath + @"\idx"));
        var analyzer = new StandardAnalyzer(_version);
        var config = new IndexWriterConfig(_version, analyzer);
        using (var indexWriter = new IndexWriter(directory, config))
        {
            indexWriter.DeleteDocuments(new Term("Id", post.Id.ToString()));
            indexWriter.Commit();
            //indexWriter.Close();
            //directory.Close();
        }
    }
    public void DeleteAllIndex()
    {
        var directory = FSDirectory.Open(new DirectoryInfo(_hostingEnvironment.WebRootPath + @"\idx"));
        var analyzer = new StandardAnalyzer(_version);
        var config = new IndexWriterConfig(_version, analyzer);
        using (var indexWriter = new IndexWriter(directory, config))
        {
            indexWriter.DeleteAll();
            indexWriter.Commit();
            //indexWriter.Close();
            //directory.Close();
        }
    }
    public  List<PostViewModel> Query(string term, int page)
    {
        string result = null;
        var directory = FSDirectory.Open(new DirectoryInfo(_hostingEnvironment.WebRootPath + @"\idx"));

        IList<Document> luceneDocuments = new List<Document>();

        IndexReader indexReader = IndexReader.Open(directory);


        var searcher = new IndexSearcher(indexReader);
        var analyzer = new StandardAnalyzer(_version);
        var parser = new MultiFieldQueryParser(_version, new[] { "Summary", "Title" }, analyzer);
        var query = parseQuery(term, parser);
        var hits = searcher.Search(query, (page + 1) * 10);
        var postViewModels=new List<PostViewModel>();
        for (int i = page * 10; i < (page + 1) * 10 && i < hits.ScoreDocs.Length; i++)
        {
            Document doc = indexReader.Document(hits.ScoreDocs[i].Doc);
            var id = doc.Get("ID");
            var title = doc.Get("Title");
            postViewModels.Add(new PostViewModel()
            {
                Id = int.Parse(id),
                Title = title
            });
             
        }
        //searcher.Close();
        //directory.Close();
        return postViewModels;
    }
    private  Query parseQuery(string searchQuery, QueryParser parser)
    {
        Query query;
        try
        {
            query = parser.Parse(searchQuery.Trim());
        }
        catch (ParseException)
        {
            query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
        }
        return query;
    }

    private  string searchByPartialWords(string bodyTerm)
    {
        bodyTerm = bodyTerm.Replace("*", "").Replace("?", "");
        var terms = bodyTerm.Trim().Replace("-", " ").Split(' ')
                                 .Where(x => !string.IsNullOrEmpty(x))
                                 .Select(x => x.Trim() + "*");
        bodyTerm = string.Join(" ", terms);
        return bodyTerm;
    }

    private  string AddHtmlStyle(string bestFragment, string id)
    {
        return "<h3> <a  href='/ShowPages.aspx?PageName=ShowNews&NewsID=" + id + "'>" + bestFragment + "</a></h3>"
            + "<div style='border-bottom: dashed 1px #999'></div><br/>";
    }

}



