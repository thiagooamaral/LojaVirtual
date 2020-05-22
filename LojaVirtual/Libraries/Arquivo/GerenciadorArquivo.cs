using LojaVirtual.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace LojaVirtual.Libraries.Arquivo
{
    public class GerenciadorArquivo
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            //Armazenar imagem em uma pasta
            var NomeArquivo = Path.GetFileName(file.FileName);
            var Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", NomeArquivo);

            using (var stream = new FileStream(Caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("/uploads/temp", NomeArquivo).Replace("\\", "/");
        }

        public static bool ExcluirImagemProduto(string caminho)
        {
            //Deletar imagem na pasta
            string Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminho.TrimStart('/'));

            if (File.Exists(Caminho))
            {
                File.Delete(Caminho);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Imagem> MoverImagensProduto(List<string> listaCaminhoTemp, int produtoId)
        {
            //Criar a pasta do produto
            var CaminhoDefinitivoPastaProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", produtoId.ToString());

            if (!Directory.Exists(CaminhoDefinitivoPastaProduto))
                Directory.CreateDirectory(CaminhoDefinitivoPastaProduto);

            //Mover a imagem
            List<Imagem> ListaImagemDef = new List<Imagem>();

            foreach (var caminhoTemp in listaCaminhoTemp)
            {
                if (!string.IsNullOrEmpty(caminhoTemp))
                {
                    var NomeArquivo = Path.GetFileName(caminhoTemp);
                    var CaminhoDef = Path.Combine("/uploads", produtoId.ToString(), NomeArquivo).Replace("\\", "/");

                    if (CaminhoDef != caminhoTemp)
                    {
                        var CaminhoAbsolutoTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", NomeArquivo);
                        var CaminhoAbsolutoDef = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", produtoId.ToString(), NomeArquivo);

                        if (File.Exists(CaminhoAbsolutoTemp))
                        {
                            //Deleta arquivo no caminho de destino
                            if (File.Exists(CaminhoAbsolutoDef))
                            {
                                File.Delete(CaminhoAbsolutoDef);
                            }

                            //Copia arquivo da pasta temporária para destino
                            File.Copy(CaminhoAbsolutoTemp, CaminhoAbsolutoDef);

                            //Deleta arquivo da pasta temporária
                            if (File.Exists(CaminhoAbsolutoDef))
                            {
                                File.Delete(CaminhoAbsolutoTemp);
                            }

                            ListaImagemDef.Add(new Imagem() { Caminho = Path.Combine("/uploads", produtoId.ToString(), NomeArquivo).Replace("\\", "/"), ProdutoId = produtoId });
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        ListaImagemDef.Add(new Imagem() { Caminho = Path.Combine("/uploads", produtoId.ToString(), NomeArquivo).Replace("\\", "/"), ProdutoId = produtoId });
                    }
                }
            }

            return ListaImagemDef;
        }

        public static void ExcluirImagensProduto(List<Imagem> ListaImagem)
        {
            int ProdutoId = 0;
            foreach (var imagem in ListaImagem)
            {
                ExcluirImagemProduto(imagem.Caminho);
                ProdutoId = imagem.ProdutoId;
            }
            var PastaProduto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", ProdutoId.ToString());

            if (Directory.Exists(PastaProduto))
            {
                Directory.Delete(PastaProduto);
            }
        }
    }
}
