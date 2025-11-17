import { useEffect, useState } from "react";
import Produto from "../../../Models/Produto";
import axios from "axios";
import { Link } from "react-router-dom";
// Componente
// 1 - Por hora deve ser uma função
// 2 - Deve retornar apenas um elemento pai HTML
// 3 - Exportar o componente
// 4 - O nome da função deve estar em PascalCase

function ListarProdutos() {

    // Estados -> São basicamente variáveis
    const[produtos, setProdutos] = useState<Produto[]>([]);

    // UseEffect é o método que permite executar algum código no momento do carregamento do componente 
    useEffect(() => {
        // Biblioteca AXIOS para requisições

        buscarProdutosAPI();

    }, []);

    async function buscarProdutosAPI(){
        try{
            const resposta = await axios.get<Produto[]>("http://localhost:5081/api/produto/listar");

            const dados = resposta.data;
            setProdutos(dados);

        } catch(error) {
            console.log("Requisição com problemas" + error);
        }
    }

    function deletarProduto(id : string) {
        deletarProdutoApi(id)
    }

    async function deletarProdutoApi(id:string) {
        try {
            const resposta = await axios.delete(
                `http://localhost:5081/api/produto/remover/${id}`
            );
            buscarProdutosAPI()
            console.log(resposta.data);
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <div id="listar_produtos">
            <h1>Listar Produtos</h1>
            <table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nome</th>
                        <th>Preço</th>
                        <th>Quantidade</th>
                        <th>Criado em</th>
                        <th>Deletar</th>
                        <th>Editar</th>
                    </tr>
                </thead>
                <tbody>
                    {produtos.map((produto : Produto) => (
                        <tr key={produto.id}>
                            <td>{produto.id}</td>
                            <td>{produto.nome}</td>
                            <td>{produto.preco}</td>
                            <td>{produto.quantidade}</td>
                            <td>{produto.criadoEm}</td>
                            <td>
                                <button onClick={() => deletarProduto(produto.id!)}>Deletar</button>
                            </td>
                            <td>
                                <Link to={`/produto/alterar/${produto.id}`}>Alterar</Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default ListarProdutos;