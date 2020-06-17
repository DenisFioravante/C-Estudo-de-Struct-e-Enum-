using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indice  = 0;
            string opcaousuario = ObterOpcaoUsuario();

            while (opcaousuario.ToUpper() != "x")
            {

                switch (opcaousuario)
                {
                    case "1":

                        //TODO: ADICIONAR ALUNOS
                        Console.WriteLine("Informe o nome do Aluno:");
                        Aluno aluno = new Aluno();
                        aluno.nome = Console.ReadLine();      
                        
                        Console.WriteLine("Informe a nota do aluno:");
                        if(decimal.TryParse(Console.ReadLine(),out decimal nota))
                        {//o tryparse verifica se o valor é possivel de converter e já declara uma variável, que no caso é nota

                                aluno.nota = nota;
                        }
                        else
                        {
                                throw new ArgumentException("Valor da Nora tem que ser Decimal");    
                        }
                        
                        alunos[indice] = aluno;   
                        indice++; 

                        break;

                    case "2":
                        //TODO: LISTAR ALUNOS

                        foreach( var a  in alunos){

                            if(!string.IsNullOrEmpty(a.nome))//se o nome não for vazio ele retorna true ou false
                            Console.WriteLine($"Aluno: {a.nome} - Nota: {a.nota}");
                        }
                          
                        break;

                    case "3":
                        //TODO: CALCULAR MÉDIA GERAL
                        decimal nota_total = 0;
                        var numAlunos = 0;

                        for(int i=0; i < alunos.Length; i++){

                              if(!string.IsNullOrEmpty(alunos[i].nome)){
                                  
                                  nota_total += alunos[i].nota;
                                  numAlunos++;  
                              }  
                        }

                        var mediaGeral = nota_total / numAlunos;
                        ConceitoEnum conceitoGeral;    

                        if(mediaGeral < 2)
                        {
                             conceitoGeral = ConceitoEnum.E;       
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }

                        Console.WriteLine($"Media Geral: {mediaGeral} - Conceito: {conceitoGeral}");

                        break;

                    default:

                        throw new ArgumentOutOfRangeException();

                }

                opcaousuario = ObterOpcaoUsuario();

            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a Opção Desejada:");
            Console.WriteLine("1-Inserir Novo Aluno:");
            Console.WriteLine("2-Listar Alunos:");
            Console.WriteLine("3-Calcular Média Geral:");
            Console.WriteLine("X-Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine();
            return opcaousuario;
        }
    }
}
