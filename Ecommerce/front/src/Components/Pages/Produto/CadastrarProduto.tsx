import { useState } from "react";
import Produto from "../../../Models/Produto";
import axios from "axios";

function CadastarProduto(){
    const [nome, setNome] = useState("");
    const [quantidade, setQuantidade] = useState(0);
    const [preco, setPreco] = useState(0);

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

            const resposta = await axios.post("http://localhost:5081/api/produto/cadastrar", produto);
            console.log(resposta);

        } catch(error){
            console.log("Erro ao cadastrar o produto: " + error);
        }
    }
    return(
        <div>
            <h1>Cadastrar Produto</h1>

            <form onSubmit={submeterProdutoAPI}>
                <div>
                    <label htmlFor="">Nome</label>
                    <input type="text" name="" id="" onChange={(e: any) => setNome(e.target.value)}/>
                </div>
                <div>
                    <label htmlFor="">Quantidade</label>
                    <input type="text" name="" id="" onChange={(e: any) => setQuantidade(e.target.value)}/>
                </div>
                <div>
                    <label htmlFor="">Preço</label>
                    <input type="text" name="" id="" onChange={(e: any) => setPreco(e.target.value)}/>
                </div>
                <div>
                    <button type="submit">Cadastrar</button>
                </div>
            </form>
        </div>
    );
}

export default CadastarProduto;