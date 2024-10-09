using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    private static string[] wordList = {   "sidewalk", "roBin", "t_hre_e", "pro_tect", "peri_od_ic",
                                    "somber", "majestic", "ju#mp", "pre_tty", "wou_nd", "jazzy",
                                    "me12mory", "jo?in", "cra_ck", "gra_de", "boot", "cloudy", "s_ick",
                                    "mug", "hot", "tart", "dangerous", "mothertheF", "rust_ic", "ec_onomic",
                                    "wei_rd", "cut", "para_llel", "wooWd", "encouraging", "intorrupt",
                                    "guidee", "lonng", "chieef", "mom", "siggnal", "re?ly", "abortive",
                                    "hai r", "repre sentative", "ear*th", "grat*e", "pr*oud", "feel",
                                    "hil*arious", "addi*tion", "silent", "play^^", "floor", "numderous",
                                    "fri end", "pizzas", "bu  ilding", "organic", "past", "mute", "unusual",
                                    "mellow", "analy se", "crate", "homely", "protest", "painstaking",
                                    "society", "head", "female", "eager", "h e a p", "dramatic", "present",
                                    "sin", "box", "pies", "aw esome", "root", "available", "sleet", "wax",
                                    "boring", "smash", "a n g e r", "tasty", "spare", "tray", "daffy", "scarce",
                                    "account", "spot", "thought", "distin_c_t", "n_i_mble", "practise", "c##ream",
                                    "blazRe", "houFghtless", "alOVVVEe", "veRdict", "gGIant"};

    public static string GetRandomWord()
    { 
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }

}