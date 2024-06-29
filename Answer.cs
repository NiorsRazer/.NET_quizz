namespace mcq
{
    public class Answer{
        public int Id {get ; set;}
        public string Text{get;set;}
        public string Type{get;set;}

        public Answer(){}

        public Answer addId(int i){
            Id=i;
            return this;
        }
        public Answer addText(string t){
            Text=t;
            return this;
        }
        public Answer addType(string t){
            Type=t;
            return this;
        }
    }
}