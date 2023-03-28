using System.Diagnostics;

namespace tSeracherr.Entity.Models
{
    public sealed class Market
    {
        public string? Name { get; set; }
        public string? TokenName { get; set; }
        public string? TokenSymbol { get; set; }
        public double? TokenPriceUsd { get; set; }
        public string? QuoteId { get; set; }
        public string? QuoteSymbol { get; set; }

        public Market() { }
        public Market(string? name, string? tokenName, string tokenAbreviated, double? tokenPriceUsd, string? quoteId, string quoteSymbol)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "The market name cannot be empty.");
            if (string.IsNullOrWhiteSpace(tokenName))
                throw new ArgumentNullException(nameof(tokenName), "The token name cannot be empty.");
            if (string.IsNullOrWhiteSpace(tokenAbreviated))
                throw new ArgumentNullException(nameof(tokenAbreviated), "The token abreviated name cannot be empty.");
            if (string.IsNullOrWhiteSpace(tokenName))
                throw new ArgumentNullException(nameof(tokenName), "The token name cannot be empty.");
            if (tokenPriceUsd < 0)
                throw new ArgumentNullException(nameof(tokenPriceUsd), "The price cannot be empty.");
            if (string.IsNullOrWhiteSpace(quoteId))
                throw new ArgumentNullException(nameof(quoteId), "The quote name name cannot be empty.");
            if (string.IsNullOrWhiteSpace(quoteSymbol))
                throw new ArgumentNullException(nameof(quoteSymbol), "The quote abreviated cannot be empty.");

            Name = name;
            TokenName = tokenName;
            TokenSymbol = tokenAbreviated;
            TokenPriceUsd = tokenPriceUsd;
            QuoteId = quoteId;
            QuoteSymbol = quoteSymbol;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Market);
        }

        public bool Equals(Market market)
        {
            return market != null
                && market.Name == Name
                && market.TokenName == TokenName
                && market.TokenSymbol == TokenSymbol
                && market.TokenPriceUsd == TokenPriceUsd
                && market.QuoteId == QuoteId
                && market.QuoteSymbol == QuoteSymbol;
                
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, TokenName, TokenSymbol, TokenPriceUsd, QuoteId, QuoteSymbol);
        }
    }
}
