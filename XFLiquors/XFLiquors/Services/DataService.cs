using System;
using System.Collections.Generic;
using System.Linq;
using XFLiquors.Models;

namespace XFLiquors.Services
{
    public static class DataService
    {
        public static List<Product> Products { get; } =
           new List<Product>
           {
                new Product()
                {
                    image = "dalmore.png",
                    description = "The Dalmore 12 Year",
                    weight = 750,
                    price = 64.99,
                    rating= 4.0,
                    groupId= 1,
                    longDescription = "The Dalmore 12 is recognized as a whisky with character far beyond its age. The spirit is initially matured in American white oak ex-Bourbon casks, yielding soft vanilla and honey notes."
                },
                new Product()
                {
                    image = "charlotte.png",
                    description = "Bruichladdich Port Charlotte Scotch",
                    weight = 700,
                    price = 63.99,
                    rating = 4.0,
                    groupId = 1,
                    longDescription = "This Port Charlotte 10 year old has been conceived, distilled, matured and bottled on Islay alone."
                },
                new Product()
                {
                    image = "jack_daniels.png",
                    description = "Jack Daniel's Old No. 7 Tennessee",
                    rating = 4.7,
                    weight = 1.75,
                    price = 45.99,
                    groupId = 1,
                    longDescription = "Mellowed drop by drop through 10-feet of sugar maple charcoal, then matured in handcrafted barrels of our own making."
                },
                new Product()
                {
                    image = "ardbeg.png",
                    description = "Ardbeg Scotch",
                    weight = 750,
                    price = 77.99,
                    rating = 4.5,
                    groupId = 1,
                    longDescription = "Ardbeg 8 Years Old is hard to miss. Probably because nobody wants to! Big, smoky and totally strange, this is dram that seems to provoke conversation."
                },
                //Beers
                new Product()
                {
                    image = "coors.png",
                    description = "Coors Light",
                    weight = 75,
                    price = 5.99,
                    rating = 4.2,
                    groupId = 2,
                    longDescription = "Coors is 4.2% ABV light beer that is always lagered, filtered, and packaged cold."
                },

                //Wine
                new Product()
                {
                    image = "silveroak.png",
                    description = "Silver Oak Cabernet Sauvignon",
                    weight = 35,
                    price = 14.99,
                    rating = 4.8,
                    groupId = 5,
                    longDescription = "Ruby in color, the 2018 Alexander Valley Cabernet Sauvignon has notes of cassis, caramel, juniper and pomegranate. Lifted and vibrant on the nose, this wine is fresh on the palate with a juice, fruit-forward core."
                },
           };

        public static List<Product> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            if(string.IsNullOrWhiteSpace(normalizedQuery))
            {
                return Products;
            }else
            return Products.Where(f => f.description.ToLowerInvariant().Contains(normalizedQuery)).
                                    OrderBy(x=>x.groupId).ThenBy(y=>y.description).ToList();
        }
    }
    
}

