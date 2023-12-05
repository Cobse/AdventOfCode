using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Dec2
    {
        public string Input { get; set; } = "two1nine\r\neightwothree\r\nabcone2threexyz\r\nxtwone3four\r\n4nineeightseven2\r\nzoneight234\r\n7pqrstsixteen";

        public Dec2()
        {
            Console.WriteLine("Dec2");
            Input = GetInput();
            Run();
            Console.ReadLine();

        }

        // In the Input example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281. Digits also have to be included.

        private void Run()
        {
            var lines = Input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var total = 0;
            foreach (var line in lines)
            {
#if DEBUG
                if (line == "51m")
                {
                    ;   
                }
#endif



                var wordsAndDigits = Regex.Matches(line, @"[a-zA-Z]+|\d+")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToArray();




                // Compare each word to the dictionary and replace with the digit and add to a new List in the same order. Also add the digits to the list.
                var digits = new List<int>();
                foreach (var word in wordsAndDigits)
                {
                    if (wordsAndDigits.Length == 1 & Regex.IsMatch(word, @"^\d+$"))
                    {
                        digits.Add(int.Parse(word[0].ToString()));
                        digits.Add(int.Parse(word[word.Length - 1].ToString()));
                    }
                    else if(word.Length == 1)
                    {
                        if (Char.IsDigit(word, 0))
                        {
                            digits.Add(int.Parse(word));
                        }
                    }
                    else if (Regex.IsMatch(word, @"^\d+$"))
                    {
                        digits.Add(int.Parse(word[0].ToString()));
                        digits.Add(int.Parse(word[word.Length - 1].ToString()));

                        //if (Array.IndexOf(wordsAndDigits, word) == 0)
                        //{
                        //    digits.Add(int.Parse(word[0].ToString()));
                        //}
                        //else
                        //{
                        //    digits.Add(int.Parse(word[word.Length - 1].ToString()));
                        //}



                    }
                    else if (_numbers.ContainsKey(word))
                    {
                        digits.Add(_numbers[word]);
                    }
                    else if (word.Length > 2)
                    {
                        try
                        {
                            for (int i = 0; i < word.Length; i += 1)
                            {
                                string chunk = word.Substring(i, 3);
                                if (_numbers.ContainsKey(chunk))
                                {
                                    int number = _numbers[chunk];
                                    digits.Add(number);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        
                    }
                }


                if (digits.Any())
                {
                    string number = string.Concat(digits.FirstOrDefault().ToString(), digits.LastOrDefault().ToString());
                    Console.WriteLine(String.Format("|{0, 40}|{1, 5}|", line, number));
                    total += int.Parse(number);

                }

            }
            Console.WriteLine($"Total: {total}");
            
        }


        // Create a dictionary of "one" : 1, "two" : 2, etc. stop at nine.

        private Dictionary<string, int> _numbers = new Dictionary<string, int>()
        {
            {"one", 1},
            {"two", 2},
            {"thr", 3},
            {"fou", 4},
            {"fiv", 5},
            {"six", 6},
            {"sev", 7},
            {"eig", 8},
            {"nin", 9}
        };

        private string GetInput()
        {
            var input = "";
            input = "threerznlrhtkjp23mtflmbrzq395three\r\n9sevenvlttm\r\n3twochzbv\r\nmdxdlh5six5nqfld9bqzxdqxfour\r\n422268\r\nvdctljvnj2jpgdfnbpfjv1\r\ntshl7foureightvzvzdcgt\r\n1fourrj\r\n6mfbqtzbprqfive\r\n4sevens34\r\nfourfourpsckl47xdbncvndrthree\r\n7ltsp1seventhreesix\r\n8sixnmm85\r\n11three\r\nfourvninelccgtkjzhhdqjmnxjbbkdsnine6two\r\nthree8seven\r\noneonefour7193eight\r\n8jmqfhmzf7\r\n5nine8\r\neight1qlfzvdtseven1threefour\r\n5slbnsevenmz\r\n8sixnzfctpblt\r\nxthzlbsjvz4dlg9fiveseven7seven\r\nfzqeightwothree1qhjtmfdsmsf\r\n74ninesixfivermkvh\r\nfive7xshrvvxbjtwo\r\n22threepdtqbceightninesevenvrsct\r\n4ttbxqm76fiveqcpdptn2\r\nfive3nrftzlzrqpkrxgtwoqplpgf\r\nthreethreeptz4\r\n755hhmsrseven\r\nsevenone1\r\ntwo7bsnxknseven\r\nthreezdbbhkrnrq4seven\r\neighttwosix71xb\r\nfourtwo86one4\r\nnxsvfqlpbtmjnjn9zkvhdn2zpn\r\n37five4mrkcjgtpldsixtwo\r\ncjbhbxx7v\r\n911lvreightfour\r\n6qptwo36onefour\r\nfscrbckvp8threemrjmgvcfknfourseven8\r\nfour48718hfour\r\nkbzfourdfxdjmmn9onefourhcxbgnlthree\r\nktvnxthree6pltdv8hqhkcmcnfj\r\n9qgnmdf\r\nninefive2\r\ntwobrcdbnninefour85\r\n4qsst9pnvtxfcrpbgt4\r\n65cdxrjxqhbr86fourvvjvsdgl3\r\nmpfsmd7five\r\n2krzxbvdgmfourthreeseven6onesevensix\r\neightone16\r\nzcslhb6hfsixnine\r\nfour44mrtqqsixtwo\r\ntwo9gqfsk2six1\r\n1zrkpqvtfhm3five4\r\n375threethree\r\ndmnjsjbqcvvqqseven3twoonesixcrdjglhdl\r\nkpkhplpf8seven\r\nzhk9ninesixbsfrg\r\n34four\r\nsevenseven8\r\ntlppzmxvgjnine9sixtxkpdone\r\ndrrzvjcgdxqmtmxffrftkthhfbqrpxmfiveseven32\r\neight4mscvrpr7\r\nsixqmndjctlnxs9q1three\r\n41mfqk81eight55\r\njhmhqzcsxfsdxkx5oneseventhree2z1\r\n6three6k\r\n6nine887\r\nhdrtcqn7zrsnrsbpxgbbsjzd\r\nhxdvfnxd1sevensixthree1eight8six\r\neightn2\r\nsevenqlcf2fiveseven6266\r\nttwone4vgtsrcds\r\nfour36\r\n52zlhmm22seven\r\nlpblvxfivethreebfslbtfour6eightone4\r\n4cbr15two3\r\n4bvxjzhbdvmjgxlqhk5cxklkx5\r\nd392qsfpkbvhlz1jkcfkcjnsdvdknqbd\r\nzffmdgmqzzsmzdqbhgjt8hhxzqvgflff22cfrnnq\r\n555onebpttwothreessdtlhkzfk\r\n7jsvkktn\r\npxslsbnlhj6fivesqdf3nhkmzzgdkckfsbxvgh\r\nsnjqcmpqf1threevxj\r\n5jkcvtsgtwo49\r\nblbsmtgjhthree9glgchhmrlnrvcvf\r\njpdvqhxrrdonebmgdbpkcj8sixfourrkrllrcv\r\n6five3smn3nine\r\nkptrrdzxcninesevenfiveeight458\r\nfourfour171twobfqcvdpx6one\r\npqrzsmqls294\r\nbx7\r\n8eightthree71fourtksmgxcz2\r\neighttwosix8mtpv\r\n8ninedrjxsbvhrsqvdpbrl97tdkxdjmq9six\r\n59twonine7ninenineninehsbqqzlr\r\nfive11\r\n6cmxnnmzmsk4lqclspone\r\ngrzqrbgtb2hztgffpzqflsqhzzdlzmktqbnjone\r\nmrmvfive37two\r\nthree5ccvghbkp3mjrsfkbpn\r\nthree94oneonethree\r\nmhoneightfivemdggmcjqgv7tlqkmhhxrjh\r\ntwodfbnnsfgnjc7fivetwo\r\nsevensix8vfvkrxninedlxdjjmlvp\r\n258\r\nphl9nine2fivefivenzzdckxdgpzrzqbkx\r\nsfmfive46one\r\nfourtwo6zjtjmtdkfzmltxdhltdzrtqp\r\n429\r\none3bzzthqjgl1skhmqvrtffpzqch\r\none7118\r\nfourninefivexzsgonefrmxpjx9svccseven\r\nvqs3fourninenine\r\nscchxmzbhqptt5\r\nseven3threetwo3\r\ngqdbqxbctkdbxf9zonevk6\r\none5dxhfrsrsz7fivesevenseven\r\n51m\r\ntwoninedfdshzcqrgvrkdrjmlqvqjhsmxlmfrhcdtbc713\r\ntwofivethree9bccssbgqnthreethree\r\nthree76hpkzttdhgj\r\n7dsseven1six9lggkdzrmjtwo\r\ndpxg7threexfvxjsqzx\r\n9191eightninekfcspxskthreethree\r\nseven5five9hrvznqxn9qtqxghtgp9\r\ngm8threefiverpbqkf5\r\n8three3eightdgn\r\n27nineeightninej\r\n43fiveprxftkhpszrgsevenninebncn\r\nthreeone7drmqtjnine2ninerjbrhtbzfkone\r\nzcplmpnbm3\r\ngllplmbp57one8fxpqbhgbln\r\nxlxfkgjvnnpbvcclcf18oneseight6\r\n51pvmcdzbnxtsevenqrvmmfhchthree\r\nnine6fdzrjone\r\n77sixbvlsfninegjq\r\n7hstqmscrqseven95ninerqjb\r\nfourthree8jfnqbbztqsevennbllxgflc5\r\nfour2threedrdqcqsbrnsix\r\none5onedplktrfb3mphprnfbcnineeighttlb\r\n8five1mscqbplsltllmqjkkcfzkh9\r\n73nine\r\none98hmlkqlnbrnbzxjd\r\nthree8onesixmckhzrlbssxhoneonexftkn\r\n6pthmtsixeightnine8one\r\nh516nine16\r\nsix83zsqd4lxqzqgcpd7twonehlj\r\nthreeseven4five35eightwont\r\nsevenfour3\r\n275779\r\npftjgl25\r\neight5oneights\r\noneeighteight8nsnzphnmspkjxzdxhvhkgrl\r\n9ninekzhkh2lfdseventwo\r\n6two81fivethree\r\nsixblhfvjfnm1mfmnpvqqnqshthreepjlzvfour9\r\n45spmbfdgdhljpdoneqclcqzccjndhqkthree6\r\n34jhrxkrtxf\r\n83mgdntfnhdj\r\nsixdtzllvpkppvlxhpkfive8sevenmdzpbnlcnfpcltg3\r\n8krd\r\nthreeqxcx8\r\nmtrssgmf85onesevenbtpmvptmjk5\r\ncgjlmfljxm98three4\r\nthreehggmbtmzjceight11\r\nmxhhvvptm95two\r\n8oneqcht3\r\nzjbfive6vvrr\r\n1mbxsvmlveight7six645crtjb\r\n6vptgkghfgzfourrsleightfive2five\r\nonejcqbtfivesixeighttwo8\r\n2eight2kqmmbsbjvxtvjhponesixtwonesn\r\n8pqeight\r\n38mfhtq95ntvbmpthreexxg\r\nsix2zhzb4dhf7threeseven\r\njskqfbsct51seven8fourn\r\njmlgbbsqtwosklzkz6five\r\nspngmplhchpqtfcksix1\r\nfiveqvsjlmlqmjzzhktkstwoeight3five\r\nthreenbf6zhtwo95nine\r\n9ltqfqqxdlv\r\ntwo6threeseven\r\nxbgzgqfvgone4fs\r\nfourfivedljcgdjrjzqmjbqqrctdvdnbjszszgpfour1\r\n82foureighteightqfmxfkvvmr\r\n991pfoursjb\r\ndeightwo7sixbtxpv5qjfhkh3\r\n482nineznmhcqhmrmbxztgkdfour9five\r\nfour9threefiveeight2eightgcm\r\n738\r\n6tfive9sixtwofour\r\ntwo9fourone8\r\n5gfnine996zgsnvjn\r\n8hpgkrndtfourtwofive\r\nsbvxxctttjmkchhlbnine8seven\r\nl9\r\nhm6xdmone5jzhppnlcs\r\nfive664\r\ngxthreemvrm5nine\r\ntjknbthreegjs8ckrrqmffhfour7\r\ntwo5bbcszdzvtpprsgkmteightfive\r\nplbtlpktcslgggpznine8sevenonejmsvg1\r\n87two85seven\r\n5fxdb5sevenseven9\r\nzgpbndt6one\r\n7239pztpqfkf\r\n768threetwocfzcvc4sx\r\npbvc34sevenone47\r\n68nine\r\nkqfxgjpnttwo84one\r\neighttxk2psqlfzf\r\nsevenshrqgptpfj88fhxgmkkz\r\n7three17one2\r\npfmxggfx8lgvvln\r\n39tsix7bkbfzqqx\r\ngtmvx3485mjtrdmsfxl9\r\n7twosevenfour9seveneight65\r\nninehscl531\r\n82rseventkhksixj\r\nvzjtwo6ztbtjpllptmznhxcnljf\r\nxrjnql792\r\n53twofourtnbfdhhr2xbsh\r\ntwogrhgmvhkgcsj2two\r\nbxlgbpnvpkrphcp54pqjhndjfmf7\r\nhszmjxgjfcnine7\r\nsixsix2\r\n688qmpnj1vsfiveeightmfrd\r\none2sixmhmlmbghfeight3\r\n5two4six1twosix\r\n58459nine3fourseven\r\n72nineonedtz88eight\r\n4lgjq\r\nlvstjk3twoninefh\r\neight161652xczvqcjhtvxgc\r\n1seven5zrkchldlfxvzrqjgzg8bl\r\nngfkczcrbrfvnsevenf4\r\nsix9fiveseven21fourfour\r\nonecsix1\r\n8fiverpnktj\r\n5eightfourmjkhskllbrb83eightkrtn\r\nhqrkbrcccd5\r\nsixjlcncnfivexqhqdbkqfour8\r\n72two\r\none8sevenfivefour\r\ndrgznqtjdfive3\r\n2vgpfdhseveneight43thtnthree\r\n2kfgbh17seven5\r\nbclqfgsdvfour9five\r\nseven48oneeightwon\r\nsixthhzzffourfivervssxzncxcthree9\r\nninefive8\r\n49sixnine73cvzgvnvvjqzmht\r\nsttbtlxgxfd69threeoneqbsmdsbpbfzpfpmf8\r\nzmxffive57\r\ndncfqshnpgmfmnpqfiveone4br2threeeight\r\n8fivetworps\r\ntwo2twoeightnine6\r\nkttfsevenfrspkpsn8cscqgvthreetwo\r\nsphvhseven1mcone8\r\nqmtlxml2onetxsjdnprxlcd7jfncngfsv\r\nonetxjrzhnb1fxnlncstxthreelsixjlqhrnjhgt\r\ntdftgntv83433\r\nsfq4dvgbmrseven6nsmxfgzfh\r\nfourmvsgfvnrpp7one36hkfcmd\r\n528dfbr4six9\r\nthreesevenfiveddpmf9five1four\r\n76ninehfivejseventhree\r\n7ninelkkdgqzgksixlhdsmvvhvseven5\r\nhrjgpzlggnine4two7\r\n2sixsixjnsfztffone7tb1\r\n6pjxcpkpdh\r\n84jsnmmllbzsseven\r\n2three572ninekn1rjqg\r\nsseightwofivenineonesixsix3gqxcnztsveight\r\nnm18sxsrgmkqsfrrcqs\r\nxsvgrddftfmt1nnmzndpc\r\nlx5jlnbzmfeighteight\r\nfdfjhnrhdbpskcpgqjhbfjxsx7\r\ntwokxnskxseventwo2xlmrtphhkvhznp\r\ntwo3mbfczdreightmxfr85\r\nrqtmx2qrhhqfmvonefour\r\n59fourjsblcnbrzmbcgdzpnrqcptn\r\n4ninexpjzqsjsznqtbclcplftnfour13six\r\nonekmj58kzvs8v\r\nfive2nineseven\r\n1two6jhdzt\r\n2n\r\ntlsbhsr1lhnjhbthz3hkgrlglzsix8l\r\nsevensevenngkc7\r\n4rxnlbqs\r\njlsg8ftfpmmlthk3fourzqmrcrx\r\ntwosixtwo94\r\n825tpltn1ssszdsdklbrjn9qtz\r\nseven96seventllvlfxddqjvtft58six\r\nseven9ndsdnone\r\nrrdmxl1\r\nfjhlhhmmsklmfhrrjhvgblgqqhtvhfpzlgshcgvh445\r\n6threetrsp75twoddj5\r\ngslbmxjn9twofivefourkbvdcpxrz4fivejbzhxjk\r\nhp6vplls1pvhscqflc\r\none91oneeight9ninesixtwo\r\nvxntwofour1\r\nfivexbslqmnsixq8\r\n8eight8two2\r\n524\r\n8five8rlkbjdsixfbqznnfive\r\nthreeseven2fourkkmhgmt\r\nsbsr2nine52seven6\r\nhxqqhcxzfour2tpbkkzpndpkthreefourfour\r\neightnbtthbztdtdv87oneonetwo\r\neightninesevennqdx5\r\nptmpmmh6\r\n5svmgf1\r\n2mhlmtbfive\r\nsixfour883\r\nx4eight239fivesl\r\nkqjzgkfs4txmfmn\r\ntwonine6hjfzkdk\r\ncntncrvfour4mnd\r\nfourhnnsksgkskq11two4\r\neightdhnine25\r\ntwo7lhbqh\r\njbjgqt5threefour44threegcn\r\n37eightpkhjshdg\r\n1seven9pqmnsix\r\n361rqvcqhv5zqzshvrffjqp4\r\nlbptzzf2ninezninesix7\r\nxvqgxhhn4694vjfdmnnine\r\nrhqjjxbn68\r\nzdoneightone3tldkfzzpbqblm12three\r\nsixnine7vss8fflxfxvvj\r\nkmpsffxpsxjbdkphpfour8cseven\r\n5hhdbthreefivepfmonesix\r\n7six13gmqvfcxrbsix\r\ntwoxtqbsbsxtdjcdzqfourrrtgs86\r\n52zdbph3kdtmpl\r\n959threethree\r\nbckxnxxvmhbz923fourthree\r\nseven2lsjr\r\nxvspjhcvpnine8sevenqjvzmjbzseven1zone\r\ntwogxgz2onefive\r\n9qmstrkqpgqzkxbbprbsixjk3sixsevenone\r\n4vzrjdvbkmlhtwo6mdkhsixfour\r\noneone2eight9zszpvnfgn3one\r\nhttbg6nztnlpgdgf\r\nqlxrnfclphthree5zbzsrszbc6\r\nctcvnkckxtgsg1ninefivecrpnqmngqvnhmqcvn\r\n9sevenfivefour\r\n6pkvvone3\r\n6nine2sixeightthree4\r\n9qfivedrpfmxfbskhfstwofivergqcg\r\n955mztjrdmlstwo5onedcrzz\r\nsevenrxbnlfpm6twozg7\r\nfour1oneseven34three3\r\nninerhc5qninefivebndtqdjrd25\r\nlsbx5bhlrjfdrmblnkl41576\r\ndvzbqqbd4615fourbjsmpvhllhjpzc\r\n657\r\n4ldkzjvdjfone\r\nnine49seven\r\n4kx2rnmpjnheighthjkxpdstb557\r\nthreeeight34three59\r\ntwofourrv48fivetwosevenddcdm\r\ngkpzqjk89\r\n341\r\ntwo5pnbbmp\r\nnine3btkkdn6\r\n339\r\n5gxcktphmzxjdtsb8\r\n8dhfzjf832\r\nbqlv7klbrbsfcbdhpcb1eightone\r\nfourcpl5mnbtzmrgdjhfl\r\n22hfmg1\r\nfiveqxtkfivethreesix5mzhj\r\nqfmfvbks1three3foureight1\r\ntwoseven8ntkbkjmtxrb33\r\n5ninensvcbfb\r\nnine2839kffmnbgvpzflmbvfpg\r\n34six2fivebdvzlbdqkl\r\n7three8five\r\nndfrcqjrn3foureightfour\r\none8pfpnpqxt49fourcspbbhlpszkxd\r\nqrmxsvjsnv2szlxhfour\r\nmpjninesixsixmngjcrphthreeseven6two\r\nvmponeightfour5\r\n776\r\n22twov7354one\r\nninexffxsqrfourcsvhgj8eightthree\r\nnghjjvxldbznlqdeight96vhhgslrddvfmc6\r\n3sixbjfvtgqp4\r\nrrqlrfksk9zpvmfqqsgdonesixseven\r\nsix1fourqhvggsfdzfckntmfbrhthree\r\none47onesmdhrtjhjk\r\nseventwoptwo7gtfzvgknbone8\r\nfoureighttwo2nnnxljzt2seven\r\nnine66threemshnrl\r\n9tbtkz98lhlprtwonevn\r\ntwo6two9867\r\n8foureightvflcsxxblgzcjmdkllblvt1\r\nfourzlcneight5\r\ntltmpnhmrbhnntmjpfkfourtnxtmtqnhrsone9\r\n838lqcmbqqrdgsix\r\nsixthreeeight9grr5nine8\r\noneeight4six68\r\nrppnht6gdrztq14five\r\n4xvgv72threev\r\nfournine2onenine2two\r\n9dhksjxmct23ninempcqhroneeight3\r\neightvhgtlfft4threethreecgnpzjf\r\nsfslpsixthreeeightcqnlpsplvtseven7nine2\r\ndrr2\r\ntwossevenhtffztninehkgzvnmgrn7one\r\nthree4fourthree6eightthree\r\neightpkgknqhfour6\r\n28onethree25\r\n1sevennine6vkrqnxct\r\n786ptjbkbf1\r\nninetjvnxqkphrltpeightthree514four\r\n376mgfkztqseven\r\n3threeqqvqxtvsnjvdkvpnvhk\r\n8rqxcrxmkxczzfkqkffvzcstwosrtmfnzmbf5eighttwo\r\ntwo93\r\n854\r\n29fourhnmjvlseightnvkfbn61\r\n6zslckzztm3eight\r\nsixfive1\r\nxzmlzvhcfk6seven8fiveeightpxbgkcl\r\nseven33bdrzdtwotvseven\r\nseven7oneeightthree\r\nj6sevenzjbf5eighttwo\r\nonegjeighteightttmknmgrmx1oneqxxfgone\r\nfljrjlk4sixone7five\r\nsevenbvqxrx27five9eight\r\nbhdfblngngtkq4\r\n3sevenfivekpgnine9\r\nnineonelqppbgtgsnine6five\r\nfdmqs1two3twothree7qdhbmkqxf\r\n176pfmhfrgvsseveneight\r\none974fourdhvbbvfive8\r\ncrlfbone3sevencjcsix\r\nrdgone8lrkhggmkttlmhvvxhvxpgkkjfllq1\r\n7xtlstglgnqoneeightfive\r\nonerjcplltnd1seven\r\ngsqtjxhd8nndrkjxgmhzdmflslthreetwotwo\r\njrspjndsvk1seven4hx\r\n5lks\r\none935onecmfrqxjxqq\r\n9npxbtsfives2\r\n9one7bghdxtv1\r\n1khgbtlhxnsevensznknbbdrvgfgpfour\r\n2sixrzlcqcrmgsxsxv\r\nsixthreezqbrlnngnpbbzp6\r\neighteightrkjphnngh4lhrrdfhbx\r\ncqbsglsixfiveonetwonvzclvsdgnmmkmchrml9\r\n7gsqfourpht3two\r\nsixsevenfoursixnine2ninemrgnlmqd9\r\n9eight2eightsixfkzlmrzqgt\r\nonethreeseven4\r\n6seveneight\r\n7rq\r\njmlbxtsxj265qssfhtlgx9\r\nthree22fiveeightfdpfthree\r\nfiveninerflxggpvflnine5dvgcl\r\n2q2twolxksmntbxrbt6\r\nc6mvlmhgbztpjhlsm2bhgnxtb65\r\n4six3six4twoonecchglvpf\r\n1eightvvhtdtwofltvfx\r\nbfnfhrlznxzszzdfoursljone922five\r\ng9\r\nhczxfzlhjntwo7ninesix35\r\n8ddh3\r\n3pjxlfour3\r\n84tcc2oneightdz\r\ntwo96\r\n8mrxsdltwo41onesix6\r\nfour1cjqeightvpghbd9qtdkjfzmmjcslv\r\noneeight3svkfzqh38threetqsxqz\r\nfour1dfhhhnhjcsdzhqdrthreethreeqxmjsdnv\r\n99eightsixone3three\r\n995432\r\nonez6five\r\n6sixtwo\r\nxhsmjfkgpninesevenfive2onepnfivefive\r\n3xvfdxnfzkvmnfvvrqjqzkkq6vrxdeight\r\nfourfiveseven386\r\n272pcvttjzdzzonegtsxqntflkppfive\r\ntone4mlskzchk9xgcht\r\nxqrkhzhghptwo18\r\ntwo25\r\nseveneight9\r\n86three6bfmdkslfmxnbqrzjltwo7\r\n6vclgmphzt7twovmvvshtslgkng6\r\ntwofourfive2nine34rmljd\r\ntwo2cjjhrtxtvxntdzxstmcsixrfnzfsdmsninejkl\r\n5ninenine9two6\r\nthreegsmgz4three86seven\r\nfive8tkdqvkmjqhdrnv9\r\ngsjhgthfqpcglnbpgfk83three2vnnhlr\r\n1three8lxqzdcjsix46oneightjhb\r\nrhlbq9txlkxvninesl\r\nsix4zldvvgjhzhszrqcdhrm9\r\nhlsqmddjmeightlfcrqkkbnssnxthree6four5\r\ngps5eighttwo93\r\n6four3eighthvhlknbxdpseven4\r\nthreespxdrjqsevenseven75pxxmphbqfhvvdtp\r\nfour8nhlsqdlgnone2seven\r\nvjcxsixthree2hspmmpqnhrddseven\r\n1tmrz8xfgtvtqmcrninedbpt739\r\nknjtcfive1eightknnbxgmsix\r\nqbj9\r\nfivefsrtdfcddfourtwojxdlmxczkljltbrct8\r\njnggmc4fourbtblkhzfnnplggfive\r\n96seven641\r\npvvqsmtqf3fourdgqrxrtxlslsone59five\r\nfive567\r\ntwo6nmhbffour38\r\nrhppzxndqrhmrxlvhn58fnseven\r\nctgjbnine9ninebkbone4nine\r\nthreeone2sixpldcvhfpfourz3\r\njxxgfvzglzrzpfk7stplphbdone8eight1\r\n3zvpstzgnz4gnfzdhnvvl\r\neightthree88sixtwosixbrr\r\nseveneightqjncs4vdqllkvmfr\r\n1five653sixonethree\r\nninehkdxcqrhszdxbgvjjkcvfmzzbq5seventhree\r\nbttqsrsz6four5tdjkmrkcqb\r\n23one35three\r\nnine4five\r\n8jhvnq1foureightsixctfxnine\r\nmscdbpkzfptqvpxd7\r\n7bmfvmtmjm\r\nfive66btxzbjmxhqljqclkponeqxcq\r\n5jpsnjbz\r\nsptwone4ffcqgfvzmsevensix\r\n27sevenqxccm\r\nbpttwonine1vrkhxkxlvd\r\nsix6rpqxbhdlgm4\r\n3threeppmfsix1one\r\ndnhbjkmhbcbzkcncmjcrmkrhmhtwo2qxblfsgtwo\r\nmpztn5\r\n8hkdnzqqs52\r\nszfsgbgxmlthreefourtwo43six1\r\ntwo5lb\r\nmv1three3d\r\ngfqn45\r\n87brnjzx\r\nzzfszvk6five\r\n3shknsmbksrxtkqdls6fivegfive\r\n5xtgdxhflbnrq\r\nonelbrxfour6\r\none3six\r\n95vqkfive\r\nlnsl6sevengxlbqqrlpdxmhjbnc\r\nvkglhnqxbffll6pseveneightninelgkqv\r\nsevendsix3ghjrlkhlkqztkksvvsrqvhfthree\r\nssfive8vmfdbfivend1xjpnjfbxxtwo\r\n8eighttwodxpjeightvzqzpltldclmbkj\r\n817rmdzceight3seven\r\n49ftonethree9\r\neighttwo5\r\n9pdzqxgpone11ggnksvvcgg9seven\r\njjljrfmdxg1fivetwo2kglgxjbjvznrb7rklzlhnpbn\r\nsrkrbfseighttwo8\r\ndsjxggrzsnnine1one1\r\n798xgsix9two\r\n956six\r\n5pnprseventhree\r\n46cpjgjxs\r\n7kpxxmmbrvm8ptwoneqht\r\n3lfghbcksg\r\n72cdcznmtsg2fiveone\r\nsevendvkzjsmsb8vmcdrxgvjv8fivenineeight\r\n3xvdjgnz17\r\nzkss7nztwo97oneightnj\r\nctgseven5nineccmbmdkgxmeight6four\r\nfive3mfkrhbzvf\r\n5one55vjsgpszbz\r\nzjbzghrbjh8fourrlpcfrxc\r\nsevengndftmqsxfjdzkjzvtwohzx83\r\n7xpqmfninesevenfdeight6fivexqfj\r\nhfpbkh325xg\r\nninefivekcsxrvjvvc7twogqxhddnine\r\nssvfgvmmv8seven799bnmn\r\nfournhvbhhx9\r\nsixfour8hbzdbkmzqj6three1\r\nfivemxhmgvxfpsxm4\r\nsevenseven1srh7\r\neight4pnsnh\r\n4gbskpjhlptkflkjgzxlxrfskxxlrxvf\r\nxmj7cngxjrnzcstrbrjsixfmqxnqnljqthreexsnfptpvd\r\nqceightcplznbthree6\r\nninebmqthreesixxfl3one4\r\nfivelb8four2one\r\n9one5jpfourfour37\r\nsevenfourtwo6zknqzv\r\ntwovbcltvfcv1ninechcjrc\r\nseventwo1five8mdxhv3three\r\nrqtgxztqntznineghqqkhfzvhmf1\r\nrloneightseven88\r\n7five81one7\r\nninepgnzpfktsslpmbonej6d\r\nktwoseven78jhsdkkbptptwop\r\nsix7nineoneninenine\r\njtcqdt1\r\n8fivetcqdglbnbxone\r\n92sdvljhqdt6zgmgsznfchjnpn1\r\nthreefour73threefive1\r\njbhqh8phjqmm\r\n4jlpncphmjjtthreethreesixpmpttpd\r\ntzxpfds4two4one7sevenjbblnlsl\r\nfxthhmseven4eighttwo\r\n2csbxskpqzqkktsv2\r\nxjfjmvtkjfoursevenone9xbrl7\r\n3ninekgg\r\n8fkmzjqdntzone43fivethree2\r\n4nine2blkhpjgpnone\r\n3six66foursix\r\n9one1\r\n4mz\r\n2fourfourone\r\n33six2fourfoursix\r\n8j\r\n59trgvlblqbk35gjeightnine\r\nfdtvfddzfourfivepnrvpr2two3\r\nctninetdv26seven\r\ncrjtlxgcbgfr8sevensix\r\nfourfourhckrdsqkq8eight\r\ntwo24kdqkzgffpxkjngj8657\r\nfoursdss33seven9zcl\r\nbhl2clcfsqnhpsixjxonefour5\r\n545vksixeight\r\nthree35five7two\r\nsevenmkddhdvqmsthree2five\r\n7zmxsix2ckskqcglhtgthree59\r\nxvsthree9\r\n22q\r\nninetwo3threenineeight8dzfrf4\r\ncqnbzgtjthreed2\r\n76jkpnonepbvhcdpfd8\r\nsevensevenmjrzvbkkknkfbq2seven5vms5\r\nthreedeight8znlvhlzpbzvhvxxmgdt\r\ncndxthxtvztwonlcqcshvnclzvxmsdrtn1\r\nhcz8vnkrrkmgpbxk2nine\r\n5h5oneeight3\r\n5m1five99six62\r\nl1eighttwofour\r\n2ccxhrlhjbr\r\ntfpzvqj4gs9\r\n6twosixfivenine1\r\n8zjsixqnrzlfxdhm8fvpfnnjxhhpggjtjnsix\r\njzmgdcptone3hqbhthree\r\njvqmsixone2hlqseven7\r\nf9eightqkdpqlctcmmzx\r\n98fivethreexgl9\r\n4bvztrtwo\r\nfivetnrqt8twokfxrsftsnfour\r\nonetwo33threenvng\r\nsixvznvnt3scseveneight81qjdbj\r\nthreenine1\r\n47rjklmqqpnthreeninehcslqslrbjtwoeight\r\n8one1twotlsgf\r\nqpzvxrb242sevenrlssthreethreem\r\neightthreethreeeightxxrz3gjmccv\r\n862seventhree5one\r\nhjjx3threegsmggrfb\r\ntwonc4eightfour43r\r\n7cblplgthnineone1\r\nfxzjsnfn2xrzfhrsq\r\none4xbvtvtxvqqmgnm9jdjxbmdjlldrqtzhrsxqseven\r\nlmgtwogqghh9five3seventwott\r\noneeight2b\r\n4five2525fivembnftdmkxzmq\r\n3m4ninefoureight6ttxrcdgnine\r\nthreeeighthcnxpqfgsvv12rkd\r\ngntcxfth588\r\nsclktwofivesnxkfq7twoxdvlxgvtzjtlgfspzk\r\nrg7\r\n3vbrgrsevenzgncpj55nine6\r\nseventhreefiveshlrnfnqjvd21tldlrkjmtwo\r\n8scjnkfpklljchzszvvfourjpvmvmgr6\r\n8fivepdlqzrsllkqkqnine9four1lqgjz\r\nqmtwone7six2one5\r\nxrvhsvkvjb2nineleightwob\r\nninefourhkdzxrgxxhfmsninedlddz5nine\r\n1sevenhslkkjfxz\r\nseven5six94ninemjvv\r\nnine4three\r\nonesktp3szmp\r\ncqconetwoninek4sevensix\r\nnine892fouronegxhscsn\r\n4mvzntcldzjxbmrrtzsheighteightbhtknp9\r\n4nineoneightfl\r\n17kdhhcnvnnq\r\nckmqgt16gs\r\nthreefivefour9\r\n3twofoursbzpbdqlj5\r\nqdxzfxdfnsgj3twofour8fivefour\r\n4xninesixzxkbqsgvpf\r\nfourqthree1nine\r\none6fivenine2txbfgfkxzfmshmzhv4eight\r\n9lhdxrmvfive\r\nxktdxtwo71\r\n225two\r\ntwo3csjhrszsfdkqmxcc3ctlhlbk4nine\r\nbfspnrjxsgoneftk1665\r\n4fivefivecsbqnljgrk\r\n8xmkhgonefivethreethreenine4zbh\r\nnineone3twofour\r\npflpcxx7two1jkzqmthreefive\r\nksnjdtfhrnvcp2six\r\nsixrfsrqfbdvn1c\r\nsixlfmqfsnnnzhmqbngct2\r\nx9x7sevenqjn\r\neightninethreeqttkfm1seven\r\n59zx923six\r\n5rnrdbmpddjldqjnrxsdsrgpfive8\r\none38432spgsfkjzeightxxk\r\n95csptxbnmdfourmzqccclqjzntftgmskvf9\r\ntlbbjckfnine6mssscphp4rzndb5three\r\n4sixnineeightztjdssbflnine\r\ndzdftgcnvvrx669\r\n6six7threeh\r\neight7onelsrkgtkgdkgsntwosixonedn\r\n4fourfourninenine1\r\nrtwonegfzmbhjbmbsvf3seven1\r\n3czkzzzvqbt5rmdskr\r\n9bmponetwo\r\nltvcjgvkqqmfivethreeeight1jls8\r\n14oneeight3qtkgbpsnseveneight2\r\ndmrgm4\r\ntwodlxpltlcxxks5\r\ntdxfeight3pqdsz35\r\n6hvfbrqccktfqhnnineone7btwovmgssfts\r\n66threedrsbtwo\r\nprbsfivetwo21ccqb5qhxz\r\nnineninebkzq829fzkd5\r\npddtlrsj7twonine5two61seven\r\nthreeeightctnkhjnqm5sevenvdjqsjpknmmslmdb\r\n76nqxdvzrninefszr31\r\n3gvgclgxbvs5eight68sixnmppfhcqhbmzq\r\n1eightrkninefive9four\r\n3hfour375three\r\neightthree54sixninenggbmckqk\r\nzbtqlmfqmbdxllqpffeight9\r\n1threehxmlj1czzlphp\r\n4four7stfrr7\r\nfour6htkfsfx3qlk41seven\r\nqsixndconehconenine12\r\nsqvvptnzbqdmgjlmctqzhlldmzthreefour8\r\nf6ssgkone\r\ntwofive8kqs\r\nfoursevenxj6two\r\nrqlqljzzdrzq4\r\none3ninefiveonesixpgjsnrvnine\r\njktfqdxpfive3bhhczvnfive\r\nfivedtcgstrzg7five7seveneight48\r\n7sevendnqnine54fivecvhzf1\r\n9fivebseven\r\nnine9mjbjmmfkpxdjhch87hpzx\r\nfivejdqrrx71sixbone6v\r\n2qkkng5\r\nfiveksvzs3threenine\r\nprtllbkjhxjhg4\r\nfctmfcrmqgq78rckrfq99d\r\n9seventnsrsbxftwothreefgpzznbjcxh\r\nthree34two\r\nggvr32sbmseven4gjfhqstzq\r\nthreefour4three\r\ntwo6sevenpzdvjdlninesevenfour\r\npgneight692vqlnhmndjvlj\r\nsix8sixqclbkscndtsfczqxhzt9bsf\r\nfivefourdlrjnbvbnine3six72five\r\n4fivefiveglchzczdstone\r\nsix4two\r\n7threefoureighteight\r\nngjpztzcshbksbzlbdnqnine4gbdsbthreetwo2\r\n39sevenseven\r\nsxcxnqrskgzkzmrkkdbxjthone3\r\n1lf9onebg\r\n9lgfxnfffh9qbdxdl65fqlsjgdljrcn\r\n37three1twofourfive\r\n92onegdcczrfrkztxttftv\r\nfxzkfnrmh7fiveggfour\r\n14fivetwoflrr59\r\n7sixtzfpxrfrtnqxvkcgtc\r\ndrmjeight1sixthreeeightrxqjknmql6vzz\r\nbsmbtp2\r\nninetworfour7vgtvfvbv\r\nninethreesccxmtmbnnine2eight1five\r\n47twothreethreeonethree7\r\nftqjtwo7dbcnfdprnn335\r\nd5three5b\r\n5eightfivevnf4one\r\n1dgtwojfxnqpc\r\nsixsixone7cpxpnzgeightbvx\r\n33\r\n7sixtwo4zjb\r\npzfxv57one9fourfour\r\n9two8\r\n5nineone1\r\none6five9twotwo2vtnqjtpxxr\r\n6threehhrmtfsgld\r\nlbdjsslmqpspxrxqtp186rzjfour\r\nsix4qd32dczd3\r\nsix5sevensix6dhlgzlfvgkthree4\r\nrmgdbsvqqnt7five\r\n8slpfjnhtggzpqr7q8three3\r\nfivecmsjjhxhh6rmvsnlfive\r\n2onejrnnkpkf7sixsixthreetqkfbk\r\nltwonejvqkzsltnine5fivemftvx\r\nfourtwolkxrtzdsninenine5pznzrqbcmnph\r\n3rzkfvqfnine\r\n6xbninefourszjltwo6\r\n59qkf96twofour\r\nfivecp37\r\nbcpmljn5\r\n7stthfdseven2threefourcrbxjjfnzbfqsfmqjlts1\r\ncpvsczrlrgnfpqbfbgh415five\r\nseventhree6\r\ntworqbfj7114clslxks9\r\nsix5eightjtnq\r\n7six9llnsseventfmflxsjkdgq\r\nsix8tznfvz3\r\nfourpnmbqdbj23\r\n2ninexltrcbkjlb\r\n665fourptmcdj\r\nseven4mkvn1tkthree8s\r\neight84one\r\nrhskrpddrmbgg7eight\r\nqgbtqls7fd63xngfvcgdp8kkffgxdcs\r\n9seventhree\r\nlslprchqthree13fourkdfsrtfrthree2\r\n246eight\r\n5ldnrqhhqmvtwojhtjhflzczsb9kklbkldvc\r\n36fivebgn3vzgvjffckfour\r\nvbxqnvhvmsix9lthree6zvmr8\r\neighttwo23\r\nflqbvc23\r\nloneightsix9two\r\nxkzvpttgfourfive6rnngs\r\nthreeseven6one5\r\nsixthree5rgklgfxllqzk4onetwo\r\none15dhhtcsx\r\nzdmhgtnsjs22fjfourqzdsvcbgq\r\n4four5\r\nhfjrsqjvtjkseven4kqcqbmbseven\r\n241lgrtbsh\r\nfiveptwo9sevenfpxpbfdoneightzj\r\n9eight923xnxgndjfg\r\ntwo8fivenine9cqcqqssbfc\r\nfivetwosevenlgrvqvtsv5tcmsvbmggvfqqg7\r\n5mgkmn6ninetwo\r\nmzsncqkbtq45r\r\nfivefivegxzjvnxcbq8ptrzpjm5three\r\n8ngzppeight646seven3oneightf\r\nsevenvcsix8\r\nvxkmqgpsixgs2\r\n9jv9\r\n17jzmvgzc\r\n6dz9\r\nsevenzzvone86twothreeonesktlhbks\r\nthree57vmlrfhcqkvlttzhcbtgqxgtbxb\r\nfiveeighteighttwotwotdtfncfjn8pkxdvkfgr\r\n8k5dsrxlvtmvdsixtwo\r\nnine2fivernnckm\r\nfpngdckp48onepbslnjdm2zbthxqp\r\nnhrl8two\r\neightczdrdrxninesdqlqhhvq7twoz\r\nsevenssmdflds6\r\n8sglqfive7p6threeqrdkmg\r\n4brkbn\r\nt4onepvf9three\r\nmdfnjqjdl2lsb2btsj\r\ntthreeljckhjqxbcjvmvx27jrffive\r\nfiveqldglnp2six9vqvdcqxbdznghqcrnbxm99\r\n9pmkfmr6sevenlfjbvxqdbstwonine\r\nthreeninezmhc8three\r\none4nine4vc\r\n8nqtgvnvcttpsrpsfive\r\npjjkmpfjpjzsbhzrgrkk96snqbtkkkd\r\n6four58fourtworg\r\n4fivekrjgx4\r\nmqrzmhhvlvknzdknine9\r\none8seven2qd5\r\npjhkthxm4\r\nsixjmbljdchjsrs3bvvnzqcqmjcm3eightwoc\r\n8ninekrb5vxhbhdtdfd7\r\n7eightvlrsklsbpc3\r\n2onethree1\r\n4nine6qvfive2dlhvfour1\r\nthreedkvnvvsmlthree149\r\nszseight88fourlfcvbzmone1dnzbnkq\r\nonekxnsfour7\r\nonefivefivefive6rmpjhdvk2\r\ntwo75\r\nxrxzfmnqrvrtflqscnhlbh14vf\r\nhsplmrdxtknine7tqtlk\r\nsncgfpvz43lvjmvrpv\r\nrdhoneightdxrvxhnthsevenfour72dxcdbmpbfd\r\nsix2oneonethree1xdszcmstmq\r\nseven1one\r\n12fourbtnxmsrvbnn6\r\nqfive7twomcmcsgsseven9\r\nfive1nine7\r\nqcntzlp8one\r\nqgpeightwosix8lbclbpknfive4ksqvptntmonevlrtrcs\r\nnxmff91hzscmcthreesh\r\n6three16\r\nhrlgqhzhqone14fivenine\r\nfournrvxrxsmvsskdnbzs5zgmfh1m\r\nfour67one8drnprkbgt\r\n81brchsdqdlk5fourseven2three\r\nninefoureightfjtmvsnine9onefive\r\ntwo7rnl6three9\r\neightseven2threethreenineqtwonezkq\r\neightcfkglfmzqjgrns99seven\r\ndbzvbkslvthreefiveeight141gcklzxrzms9\r\n4frfvf6fourgnsm\r\n7hcgjbbpbl9qbzzhfq\r\nmnfllkcqgkninefive9\r\n4qdld5hqgrthreeeight2\r\nxlnnine6lksthree\r\nlkvcnntznk33three4nine\r\n8five2twonem\r\n695mzfnhtlbhpvn1dfour4\r\n47seven811tzhqrrshdm\r\nvgoneightnsr3fivethreetwornvbz\r\ngc2\r\n3sevenxvmzbpknnqninetwofourtwosbpmqk\r\n4seven8\r\n2fivegk47gsqtvdms\r\n1jqgxbmgs4zxkrtvvtsjf1nfsdgtqrmthreeeight\r\nvbvjdlnfiveninefive162nine\r\njqqsfqbfq2clfmfxz\r\n2hmn1v2twofour16\r\nphchfbxz3one\r\nzdcqgg34vqkhlbkc96six7\r\n5eightbghcktjjninermkpmbpk\r\n4zctvpqqfxqdpf\r\nsix5onebljkhvlzfour3vf7\r\nthree7sevenspczxeight3\r\neightsjxdbgcjllvpxn5ninehrhlp\r\nr4\r\nvtkqxmmdfkmbxbvgr633\r\nnrtfbqdthb1974jsdfive7jc\r\ntwothreenineeight3\r\nseven9c9\r\nl4rmngrjjl8phsftfrtwoninethree\r\n8hptpqbfltv6twovcz5twothreethree\r\nhncsxnxrbx174dbsddg9n\r\n7fpvztb\r\neightnineq5kkd1seven\r\ngbj8rvvqjkbp\r\nsevenninecjrxhfsevenfivembxm1nkjrdtrllqrglrrxxj\r\n21eightfive84mkdnzone\r\n3rqjlbfzjninesncjnxxqnine9\r\ncvtwone2k1zmp65\r\n1v\r\none7eighteightsixqkfsm\r\n44jkrsmcthreekktxlnnzjdslhfsmzl\r\ndmhxlbsixh35\r\nfour8ninetwofour864\r\n5threezmcq\r\n6ninefive7\r\n4nine9twooneeightwoz\r\n5klvpcfxpkhdhx717\r\n6stgznine4vhnsnhts9\r\n9threeone98seven1vnnvgxslf\r\nsixeighteightztpdhvt2zqjstmzmtzgsfthreezzhhdr\r\ntwodtbkqsjgtwohfnsqcrmpjfourhkpnsfdkfive6four\r\nggrxkrdzmthree3\r\nsixlflcmmjrs5fivenine488\r\nfour94hmhvlczssonedvgchseven6\r\nssoneightfbfctjqv43psixsevenslqsfpkb1\r\nbdpnkb9eightnvtwojxbztssqfmninethree\r\ncpcnkvdbrqrxtfnmzbqgffivesix91fivehgrv\r\nfive5495eight2\r\n7foursix93seventwonbhtmfrbqgq\r\ntpqhxqqxpcnmlhqhkz123ninefive\r\nknqxmrrmninegr4\r\n14qhlbkthreellvnqpfpbb\r\n7eightcrlb6eightthree7\r\ntwom3\r\ngtzdljfdzpdg4zbnzbnxmpcpfsevennine3\r\nsvfjvnninefourpqsdmjcfhvccnjkpf8\r\ndzmoneighttwovk5tvpnmxfive\r\n88msthvt4vbmnbrzjone\r\nnbgcs8nine\r\n4three53pczsx1sevenmzmtrzz\r\nfour24qphdrxfsf\r\ngdgj3f\r\nhthphptmmtwo7sixsevenoneightls\r\nqxbhjmmqsixfkfn36three6\r\neightmkmdtvkctkvptsbckzpnkhpskdmp3\r\nsix2twobgzsfsptlqnine42xtmdprjqc\r\npxreightwo7";
            return input;
        }


    }
}
