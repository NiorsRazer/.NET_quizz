namespace mcq
{
    public class Question{
        public int Id{get;set;}
        public List<Answer> ListAnswers{get;set;}

        public Question(){}

        public Question AddId(int i){
            Id=i;
            return this;
        }

        public Question AddListAnswers(List<Answer> a){
            ListAnswers=a;
            return this;
        }
    }
}