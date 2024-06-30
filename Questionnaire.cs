namespace mcq
{
    public class Questionnaire{
        public List<Question> questions;
        public List<Question> ListQuestion{get;set;}

        public Questionnaire(){}
        public Questionnaire( List<Question> l){
            ListQuestion=l;
        }
    }
}