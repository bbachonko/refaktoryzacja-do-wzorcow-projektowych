using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose {
        private readonly IList<Item> Items;
        private readonly Dictionary<string, IItemStrategy> Strategies;

        public GildedRose(IList<Item> items) {
            Items = items;
            Strategies = new Dictionary<string, IItemStrategy> {
                { "Aged Brie", new AgedBrieStrategy() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassesStrategy() },
                { "Sulfuras, Hand of Ragnaros", new SulfurasStrategy() },
                { "Default", new DefaultItemStrategy() }
            };
        }

        public void UpdateQuality() {
            foreach (var item in Items) {
                if (Strategies.TryGetValue(item.Name, out var strategy)) {
                    strategy.Update(item);
                } else {
                    Strategies["Default"].Update(item);
                }
            }
        }
    }

    public interface IItemStrategy {
        void Update(Item item);
    }

    public class AgedBrieStrategy : IItemStrategy {
        public void Update(Item item) {
            item.SellIn--;
            item.Quality = System.Math.Min(50, item.Quality + 1);

            if (item.SellIn < 0) {
                item.Quality = System.Math.Min(50, item.Quality + 1);
            }
        }
    }

    public class BackstagePassesStrategy : IItemStrategy {
        public void Update(Item item) {
            item.SellIn--;

            if (item.SellIn < 0) {
                item.Quality = 0;
                return;
            }

            if (item.SellIn < 5) {
                item.Quality = System.Math.Min(50, item.Quality + 3);
            } else if (item.SellIn < 10) {
                item.Quality = System.Math.Min(50, item.Quality + 2);
            } else {
                item.Quality = System.Math.Min(50, item.Quality + 1);
            }
        }
    }

    public class SulfurasStrategy : IItemStrategy {
        public void Update(Item item) {
            // "Sulfuras" items do not change in quality or sell-in.
        }
    }

    public class DefaultItemStrategy : IItemStrategy {
        public void Update(Item item) {
            item.SellIn--;
            item.Quality = System.Math.Max(0, item.Quality - 1);

            if (item.SellIn < 0) {
                item.Quality = System.Math.Max(0, item.Quality - 1);
            }
        }
    }

    public class Item {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
