using System;
using System.Globalization;
using Word = NetOffice.WordApi;
namespace DispatcherServiceApp
{
    public static class WordHelper
    {
        public static void Export(int id)
        {
            Word.Application wordApp=null;
            Word.Document wordDoc=null;
            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = true;
                wordDoc = wordApp.Documents.Open(Environment.CurrentDirectory + @"\Шаблон.docx");
                
                var document=GetDocument(id);
                var firstDate=DateTime.ParseExact(document.FirstDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                var lastDate=DateTime.ParseExact(document.LastDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                var nowDate=DateTime.Now;
                wordDoc.Bookmarks["Номер_карточки"].Range.GetFormatingRange(document.Id.ToString());
                wordDoc.Bookmarks["Заявитель"].Range.GetFormatingRange($"{document.LName} {document.FName} {document.SName}");
                wordDoc.Bookmarks["Телефон"].Range.GetFormatingRange(document.Phone);
                wordDoc.Bookmarks["Улица"].Range.GetFormatingRange(document.Street);
                wordDoc.Bookmarks["Дом"].Range.GetFormatingRange(document.HomeNumber.ToString());
                wordDoc.Bookmarks["Квартира"].Range.GetFormatingRange(document.Apartment.ToString());
                wordDoc.Bookmarks["Содержание"].Range.GetFormatingRange(document.DescriptionProblem);
                wordDoc.Bookmarks["Работник"].Range.GetFormatingRange(document.Worker);
                wordDoc.Bookmarks["Дата_поступления"].Range.GetFormatingRange(firstDate.ToLongDateString());
                wordDoc.Bookmarks["Текущая_дата"].Range.GetFormatingRange(nowDate.ToLongDateString());
                wordDoc.Bookmarks["Дата_выполнения"].Range.GetFormatingRange(lastDate.ToLongDateString());
                wordDoc.Bookmarks["Результаты"].Range.GetFormatingRange(document.DescriptionResult);
                wordDoc.Bookmarks["Сумма"].Range.GetFormatingRange(document.Money.ToString());
            }
            finally
            {
                wordDoc?.Dispose();
                wordApp?.Quit();
            }


        }
        private static Word.Range GetFormatingRange(this Word.Range range,string text)
        {
            range.Font.Bold=2;
            range.Font.Size=14;
            range.Text=text;
            return range;
        }
        private static Document GetDocument(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Documents.Find(id);

            }
        }
    }
}
