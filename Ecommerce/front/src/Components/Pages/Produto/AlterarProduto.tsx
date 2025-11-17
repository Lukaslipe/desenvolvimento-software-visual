import { useEffect, useState } from "react";
import Produto from "../../../Models/Produto";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

function AlterarProduto(){
    const {id} = useParams();
    const [nome, setNome] = useState("");
    const [quantidade, setQuantidade] = useState(0);
    const [preco, setPreco] = useState(0);
    const navigate = useNavigate();

    useEffect(() => {
        buscarProduto();
    }, [])

    async function buscarProduto(){
        try {
            const resposta = await axios.get<Produto>(
                `http://localhost:5081/api/produto/buscar/${id}`
            );
            setNome(resposta.data.nome);
            setQuantidade(resposta.data.quantidade);
            setPreco(resposta.data.preco);
        } catch (error) {
            console.log(error)
        }
    }

    function submeterProdutoAPI(e : any){
        e.preventDefault()
        enviarProdutoAPI();
    }

    async function enviarProdutoAPI() {
        try {
            const produto : Produto = {
                nome,
                quantidade,
                preco
            }

            const resposta = await axios.patch(`http://localhost:5081/api/produto/editar/${id}`, produto);
            console.log(resposta);

        } catch(error){
            console.log("Erro ao cadastrar o produto: " + error);
        }
    }
    return(
        <div>
            <h1>Alterar Produto</h1>

            <form onSubmit={submeterProdutoAPI}>
                <div>
                    <label htmlFor="">Nome</label>
                    <input type="text" name="" id="" value={nome} onChange={(e: any) => setNome(e.target.value)}/>
                </div>
                <div>
                    <label htmlFor="">Quantidade</label>
                    <input type="text" name="" id="" value={quantidade} onChange={(e: any) => setQuantidade(e.target.value)}/>
                </div>
                <div>
                    <label htmlFor="">Preço</label>
                    <input type="text" name="" id="" value={preco} onChange={(e: any) => setPreco(e.target.value)}/>
                </div>
                <div>
                    <button type="submit">Salvar</button>
                </div>
            </form>
        </div>
    );
}

export default AlterarProduto;