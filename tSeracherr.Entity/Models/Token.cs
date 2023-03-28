namespace tSeracherr.Entity.Models
{
    public sealed class Token
    {
        public int Number { get; set; }
        public string? FullName { get; set; }
        public string? Symbol { get; set; }
        public decimal Price { get; set; }

        public Token() { }
        public Token(int number, string fullName, string symbol, decimal price)
        {
            if (number < 0)
                throw new ArgumentNullException(nameof(number), "The sequence number cannot be less than or equal to null.");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(FullName), "The full name cannot be empty.");
            if (string.IsNullOrWhiteSpace(symbol))
                throw new ArgumentNullException(nameof(symbol), "The abreviated name cannot be empty.");
            if (price < 0)
                throw new ArgumentNullException(nameof(price), "The price cannot be less than or equal to null.");

            Number = number;
            FullName = fullName;
            Symbol = symbol;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Number} {FullName} {Symbol} {Math.Round(Price, 4)}$";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Token);
        }

        public bool Equals(Token token)
        {
            return token != null
                && token.Number == Number
                && token.FullName == FullName
                && token.Symbol == Symbol
                && token.Price == Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number, FullName, Symbol, Price);
        }
    }
}
