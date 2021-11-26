using System;

namespace Revisão
{
    
    class Program
    {

        static void Main(string[] args)
        {            
            Aluno[] alunos = new Aluno[5];
            var indeceAluno = 0;
            string opcaouser = MetodoMenu();

            while (opcaouser.ToUpper() != "X")
            {

                switch(opcaouser)
                {
                    //Inserir aluno
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno:");
                        //Tratamento da vareável recebida pelo usuário
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRageException("Valor da nota deve ser decimal");
                        }
                        alunos[indeceAluno] = aluno;
                        indeceAluno++;
                    break;

                    //Listar alunos
                    case "2":
                        // Um forreach para percorrer a lista de alunos
                        foreach(var a in alunos)
                        {
                            //Condição pa exibir aluno se existeir aluno na lista
                            if(!string.isNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }                            
                        }
                    break;

                    //Calcular média geral
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for(int i=0; i <  alunos.Length; i++)
                        {
                            if(!string.isNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                         else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                    break;
                    
                    //Caso usuário digite um número fora do menu acima
                    default:
                        throw new ArgumentOutOfRageException();

                }

                opcaouser = MetodoMenu();
                
            }

        }

        //Criação de um métdodo que execulta o menu de escolha do usuário, evitando reescrever código
        private static string MetodoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaouser = Console.ReadLine();
            Console.WriteLine();
            return opcaouser
        }

    }
}
