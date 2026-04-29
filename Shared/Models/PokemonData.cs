using Microsoft.Identity.Client;
using MudBlazor;
using System.Reflection.Metadata;

namespace DamageCalcChamp.Shared.Models
{
    public class PokemonDataReal
    {
        public string Name { get; set; }
        public int HP, Attack, Block, Contact, Defense, Speed, Level;
        public string[] type = { "", "" };
        public string TeraType;
        public string ability;
        public int ZukanNo;
        public double Height, Weight;
        public List<string> MoveList;
        public bool[] Options = new bool[30];
        public string Item;
        public int[] Rank = { 0, 0, 0, 0, 0 };
        public int Special;

        public PokemonDataReal(string name, string t1, string t2, string t3, int L, int h, int a, int b, int c, int d, int s,
            int zukanNo, double height, double weight, string abl, string item, int[] r, bool[] opt, int spe, List<string> moveList)
        {
            Name = name; Level = L;
            HP = h; Attack = a; Block = b; Contact = c; Defense = d; Speed = s;
            type[0] = t1; type[1] = t2; TeraType = t3;
            ability = abl;
            ZukanNo = zukanNo; Height = height; Weight = weight;
            Item = item;
            Rank = r;
            Options = opt;
            Special = spe;
            MoveList = moveList;
        }
    }
    public class PokemonData
    {
        public string Name { get; set; }
        public int HP, Attack, Block, Contact, Defense, Speed;
        public string[] type = { "", "" };
        public string[] ability = { "", "", "" };
        public int ZukanNo;
        public double Height, Weight; 
        public List<string> MoveList = new List<string>();

        public PokemonData(string name, string t1, string t2, int h, int a, int b, int c, int d, int s,
            int zukanNo, double height, double weight, string ability1, string ability2, string ability3,
            params string[] moveList )
        {
            Name = name;
            HP = h; Attack = a; Block = b; Contact = c; Defense = d; Speed = s;
            type[0] = t1; type[1] = t2;
            ability[0] = ability1; ability[1] = ability2; ability[2] = ability3;
            ZukanNo = zukanNo; Height = height; Weight = weight;

            foreach( string move in moveList )
            {
                MoveList.Add( move );
            }
        }
    }

    public partial class  PokemonDataManager
    {
        private List<PokemonData> PokemonList = new List<PokemonData>();
        private List<string> PokemonNameList = new List<string>();

        public List<string> AllPokemonName()
        {
            return (PokemonNameList);
        }
        public PokemonData? GetPokemonData( string name )
        {
            try {
                var val = PokemonList.Where(x => x.Name == name).ToList();
                return (val[0]);
            } catch ( Exception e ) {
                return (null);
            }
        }

        // データベースを使うのはしんどそうなので、全部ここに書いてしまう
        private void AddPokemonData(string name, string type1, string type2,
            int HP, int Attack, int Block, int Contact, int Defense, int Speed,
            int zukanNo, double height, double weight, string ability1, string ability2, string ability3,
            params string[] movelist)
        {
            PokemonList.Add( new PokemonData(name, type1, type2,
                HP, Attack, Block, Contact, Defense, Speed,
                zukanNo, height, weight, ability1, ability2, ability3,
                movelist
                ) );
            PokemonNameList.Add(name);
        }
    }
}
