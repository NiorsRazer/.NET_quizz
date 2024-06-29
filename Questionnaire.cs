namespace mcq
{
    public class Questionnaire{
        public List<Question> ListQuestion{get;set;}

        public Questionnaire( List<Question> l){
            ListQuestion=l;
        }
    }
}