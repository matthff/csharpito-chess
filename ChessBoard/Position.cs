namespace ChessBoard{
    class Position{
        public int Line { get; set; }
        public int Column { get; set; }


        public Position(int line, int column){
            Line = line;
            Column = column;
        }

        public void SetPosition(int line, int column){
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"Position: {Line}|{Column}";
        }
    }
}