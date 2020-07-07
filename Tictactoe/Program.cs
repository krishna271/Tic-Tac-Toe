using System;

namespace Tictactoe
{
    class Game
    {
        public char[,] locations=new char[3,3]{
                                        {'1','2','3'},
                                        {'4','5','6'},
                                        {'7','8','9'}
                                        };

        public void display(){
            for(int i=0; i<3; i++){
                for(int j=0;j<3;j++){
                    if(j==2){
                        Console.WriteLine(" {0}",locations[i,j]);
                    }
                    else{
                        Console.Write(" {0} |",locations[i,j]);
                    }
                }
                if(i<2)
                Console.WriteLine("--- --- ---");
            }
        }
        public void updateLoc(int loc, int chance)
        {
            int row=0;
            int column=0;
            if(loc==1){
                row=0;
                column=0;
            }
            else if(loc==2)
            {
                row=0;
                column=1;
            }
            else if(loc==3)
            {
                row=0;
                column=2;
            }
            else if(loc==4)
            {
                row=1;
                column=0;
            }
            else if(loc==5)
            {
                row=1;
                column=1;
            }
            else if(loc==6)
            {
                row=1;
                column=2;
            }
            else if(loc==7)
            {
                row=2;
                column=0;
            }
            else if(loc==8)
            {
                row=2;
                column=1;
            }
            else
            {
                row=2;
                column=2;
            }

            if(chance==0 && locations[row,column]!='X' && locations[row,column]!='O')
            {
                locations[row,column]='X';
            }
            else if(chance==1 && locations[row,column]!='X' && locations[row,column]!='O')
            {
                locations[row,column]='O';
            }else{
                Console.WriteLine("Invalid location");
            }
        }
         public int checkWinner()
        {
            int person=0;
            for (int i = 0; i < 3; i++)
            {
                if(locations[i,0]=='X' && locations[i,1]=='X' && locations[i,2]=='X'){
                    person=1;
                }
                else if(locations[i,0]=='O' && locations[i,1]=='O' && locations[i,2]=='O'){
                    person=2;
                }
            }
            if(person==0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if(locations[0,i]=='X' && locations[1,i]=='X' && locations[2,i]=='X'){
                        person=1;
                    }
                    else if(locations[0,i]=='O' && locations[1,i]=='O' && locations[2,i]=='O'){
                        person=2;
                    }
                }
            }
            if(person==0){
                if((locations[0,0]=='X' && locations[1,1]=='X' && locations[2,2]=='X')||(locations[0,2]=='X' && locations[1,1]=='X' && locations[2,0]=='X')){
                    person=1;
                }
                else if((locations[0,0]=='O' && locations[1,1]=='O' && locations[2,2]=='O')||(locations[0,2]=='O' && locations[1,1]=='O' && locations[2,0]=='O')){
                    person=2;
                }
            }
            return person;
        }
        public int checkFull(){
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    if(locations[i,j]=='X' || locations[i,j]=='O'){
                        continue;
                    }
                    else{
                        return 0;
                    }
                }
            }
            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            int chance=0;
            while(true){
                Console.WriteLine("person-1 X and person-2 O\n");
                g.display();
                if(chance==0)
                {
                    Console.WriteLine("\nperson-1 turn ");
                }
                else
                {
                    Console.WriteLine("\nperson-2 turn ");
                }
                String val=Console.ReadLine();
                int loc = Convert.ToInt32(val);
                Console.Clear();
                g.updateLoc(loc,chance);
                int person=g.checkWinner();
                if(chance==0)
                {
                    chance=1;
                }
                else{
                    chance=0;
                }
                if(g.checkFull()==1){
                    Console.WriteLine("Draw");
                    break;
                }
                if(person==0)
                {
                    continue;
                }
                else if(person==1){
                    Console.WriteLine("Winner is person-1");
                    break;
                }
                else{
                    Console.WriteLine("Winner is person-2");
                    break;
                }
            }
        }
    }
}
