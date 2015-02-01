﻿using System.Collections.Generic;
using System.IO;
using System;

public class RareData
{
    private static bool usingHardcoded;
    public class RareCache
    {
        public List<RareGood> rares;

        public RareCache()
        {
            rares = null;
        }

        public RareCache(List<RareGood> r)
        {
            rares = r;
        }
    }

    public static List<RareGood> HardcodedRares()
    {
        List<RareGood> temp = new List<RareGood>();
        temp.Add(new RareGood("39 Tauri", "Porta", "Tauri Chimes"));
        temp.Add(new RareGood("Aegaeon", "Schweikart Station", "Chateau De Aegaeon"));
        temp.Add(new RareGood("Aerial", "Andrade Legacy", "Edan Apples of Aerial"));
        temp.Add(new RareGood("Alacarakmo", "Weyl Gateway", "Alacarakmo Skin Art"));
        temp.Add(new RareGood("Alpha Centauri", "Hutton Oribtal", "Centauri Mega Gin"));
        temp.Add(new RareGood("Altair", "Solo Orbiter", "Altairian Skin"));
        temp.Add(new RareGood("Alya", "Malaspina Gateway", "Alya Body Soup"));
        temp.Add(new RareGood("Anduliga", "Celsius Estate", "Anduliga Fire Works"));
        temp.Add(new RareGood("Any Na", "Libby Orbital", "Any Na Coffee"));
        temp.Add(new RareGood("Arouca", "Shipton Orbital", "Arouca Conventula Sweets"));
        temp.Add(new RareGood("AZ Cancri", "Fisher Station", "Az Cancri Formula 42"));
        temp.Add(new RareGood("Baltah'Sine", "Baltha'sine Station", "Baltha'sine Vacuum Krill"));
        temp.Add(new RareGood("Banki", "Parsons Vista", "Banki Amphibious Leather"));
        temp.Add(new RareGood("Bast", "Hart Station", "Bast Snake Gin"));
        temp.Add(new RareGood("Belalans", "Boscovich Ring", "Belalans Ray Leather"));
        temp.Add(new RareGood("Borasetani", "Katzenstien Terminal", "Borasetani Pathogenetics"));
        temp.Add(new RareGood("CD-75 661", "Kirk Dock", "CD-75 Kitten Brand Coffee"));
        temp.Add(new RareGood("Cherbones", "Chalker Landing", "Cherbones Blood Crystals"));
        temp.Add(new RareGood("Chi Eridani", "Steve Masters station", "Chi Eridani Marine Paste"));
        temp.Add(new RareGood("Coquim", "Hirayama Installation", "Coquim Spongiform Victuals"));
        temp.Add(new RareGood("Damna", "Nemere Market", "Damna Carapaces"));
        temp.Add(new RareGood("Dea Motrona", "Pinzon Dock", "Motrona Experience Jelly"));
        temp.Add(new RareGood("Delta Phoenicis", "Trading Post", "Delta Phoenicis Palms"));
        temp.Add(new RareGood("Diso", "Shifnalport", " Diso Ma Corn"));
        temp.Add(new RareGood("Eleu", "Finney Dock", "Eleu Thermals"));
        temp.Add(new RareGood("Epsilon Indi", "Mansfield Orbiter", "Indi Bourbon"));
        temp.Add(new RareGood("Eranin", "Azeban City", "Eranin Pearl Whiskey"));
        temp.Add(new RareGood("Eshu", "Shajn Terminal", "Eshu Umbrellas"));
        temp.Add(new RareGood("Esuseku", "Savinykh Orbital", "Esuseku Caviar"));
        temp.Add(new RareGood("Ethgreze", "Bloch Station", "Ethgreze Tea Buds"));
        temp.Add(new RareGood("Fujin", "Futen Starport", "Fujin Tea"));
        //temp.Add(new RareGood("George Pantazis", "Zakam Platform", "Pantaa Prayer Sticks")); // This system is still not in EDStarCoordinator for some reason
        temp.Add(new RareGood("Geras", "Yurchikhin Port", "Gerasian Gueuze Beer"));
        temp.Add(new RareGood("Goman", "Gustav Sporer Port", "Goman Yaupon Coffee"));
        temp.Add(new RareGood("Haiden", "Searfoss Enterprise", "Haidne Black Brew"));
        temp.Add(new RareGood("Havasupai", "Lovelace Port", "Havasupai Dream Catcher"));
        temp.Add(new RareGood("Hecate", "RJH1972", "Live Hecate Sea Worms"));
        temp.Add(new RareGood("Heike", "Brunel City", "Ceremonial Heike Tea "));
        temp.Add(new RareGood("Helvetitj", "Friend Orbital", "Helvetitj Pearls"));
        temp.Add(new RareGood("HIP 10175", "Stefanyshyn-Piper Station", "HIP 10175 Bush Meat"));
        temp.Add(new RareGood("HIP 41181", "Andersson Station", "HIP Proto"));
        temp.Add(new RareGood("HIP 59533", "Burnham Beacon", "Burnham Bile Distillate"));
        temp.Add(new RareGood("Holva", "Kreutz Orbital", "Holva Duelling Blades"));
        temp.Add(new RareGood("HR 7221", "Veron City", "HR 7221 Wheat"));
        temp.Add(new RareGood("Irukama", "Blaauw City", "Giant Irukama Snails"));
        temp.Add(new RareGood("Jaradharre", "Gohar Station", "Jaradharre Puzzle Box"));
        temp.Add(new RareGood("Jaroua", "Mccool City", "Jaroua Rice"));
        temp.Add(new RareGood("Kachirigin", "Nowak Orbital", "Kachirigin Filter Leeches"));
        temp.Add(new RareGood("Kamitra", "Hammel Terminal", "Kamitra Cigars"));
        temp.Add(new RareGood("Kamorin", "Godwin Vision", "Kamorin Historic Weapons"));
        temp.Add(new RareGood("Kappa Fornacis", "Harvestport", "Onion Head"));
        temp.Add(new RareGood("Karetii", "Sinclair Platform", "Karetii Couture"));
        temp.Add(new RareGood("Karsuki Ti", "West Market", "Karsuki Locusts"));
        temp.Add(new RareGood("Kongga", "Laplace Ring", "Kongga Ale"));
        temp.Add(new RareGood("Korro Kung", "Lonchakov Orbital", "Koro Kung Pellets"));
        temp.Add(new RareGood("Lave", "Lave Station", "Lavian Brandy"));
        temp.Add(new RareGood("Leesti", "George Lucas", "Leestian Evil Juice"));
        temp.Add(new RareGood("Leesti", "George Lucas", "Azure Milk"));
        temp.Add(new RareGood("LFT 1421", "Ehrlich Orbital", "Void Extract Coffee"));
        temp.Add(new RareGood("Mechucos", "Brandenstein Port", "Mechucos High Tea"));
        temp.Add(new RareGood("Medb", "Vela Dock", "Medb Starlube"));
        temp.Add(new RareGood("Mokojing", "Noli Terminal", "Mokojing Beast Feast"));
        temp.Add(new RareGood("Momus Reach", "Tartarus Point", "Momus Bog Spaniel"));
        temp.Add(new RareGood("Mukusubii", "Ledyard Dock", "Mukusubii Chitin"));
        temp.Add(new RareGood("Mulachi", "Clark Terminal", "Mulachi Giant Fungus"));
        temp.Add(new RareGood("Neritus", "Toll Ring", "Neritus Berries"));
        temp.Add(new RareGood("Ngadandari", "Consolmagno Horizons", "Ngadandari Fire Opals"));
        temp.Add(new RareGood("Nguna", "Biggle Hub", "Nguna Modern Antiques"));
        temp.Add(new RareGood("Njangari", "Lee Hub", "Njangari Saddles"));
        temp.Add(new RareGood("Ochoeng", "Roddenberry Gateway", "Ochoeng Chillies"));
        temp.Add(new RareGood("Orrere", "Sharon Lee Free Market", " Orrerian Vicious Brew"));
        temp.Add(new RareGood("Quechua", "Crown Ring", "Albino Quechua Mammoth Meat"));
        temp.Add(new RareGood("Rapa Bao", "Flagg Gateway", "Rapa Bao Snake Skins"));
        temp.Add(new RareGood("Rusani", "Fernandes Market", "Rusani Old Smokey"));
        temp.Add(new RareGood("Shinrarta Dezhra", "Jameson Memorial", "Waters of Shintara"));
        temp.Add(new RareGood("Tarach Tor", "Tranquillity", "Tarach Spice"));
        temp.Add(new RareGood("Tanmark", "Cassie-L-Peia", "Tanmark Tranquil Tea"));
        temp.Add(new RareGood("Thrutis", "Kingsbury Dock", "Thrutis Cream"));
        temp.Add(new RareGood("Tiolce", "Gordon Terminal", "Tiolce Waste 2 Paste"));
        temp.Add(new RareGood("Toxandji", "Tsunenaga Orbital", "Toxandji Virocide"));
        temp.Add(new RareGood("Uszaa", "Guest Installation", "Uszaian Tree Grub"));
        temp.Add(new RareGood("Utgaroar", "Fort Klarix", "Utgaroar Millennial Eggs"));
        temp.Add(new RareGood("Uzumoku", "Sverdrup Ring", "Uzumoku Low"));
        temp.Add(new RareGood("Vanayequi", "Clauss Hub", "Vanayequi Ceratomorpha Fur"));
        temp.Add(new RareGood("Vega", "Taylor City", "Vega Slimweed"));
        temp.Add(new RareGood("Vidavanta", "Lee Mines", "Vidavantian Lace"));
        temp.Add(new RareGood("Wolf 1301", "Saunders's Dive", "Wolf Fesh"));
        temp.Add(new RareGood("Wheemete", "Eisinga Enterprise", "Wheemete Wheat Cakes"));
        temp.Add(new RareGood("Witchhaul", "Hornby Terminal", "Witchhaul Kobe Beef"));
        temp.Add(new RareGood("Wuthielo Ku", "Tarter Dock", "Wuthielo Ku Froth"));
        temp.Add(new RareGood("Xihe", "Zhen Dock", "Xihe Biomorphic Companions"));
        temp.Add(new RareGood("Yaso Kondi", "Wheeler Market", "Yaso Kondi Leaf"));
        temp.Add(new RareGood("Zaonce", "Ridley Scott", "Leathery Eggs"));
        temp.Add(new RareGood("Zeessze", "Nicollier Hanger", "Zeessze Ant Grub Glue"));
        return temp;
    }

    public static bool UsingHardcoded()
    {
        return usingHardcoded;
    }

    public static List<RareGood> GetRares()
    {
        RareCache cache;
        if (LocalData<RareCache>.LoadRunData("Rares.xml", out cache))
        {
            usingHardcoded = false;
            return cache.rares;
        }
        usingHardcoded = true;
        return HardcodedRares();
    }
}