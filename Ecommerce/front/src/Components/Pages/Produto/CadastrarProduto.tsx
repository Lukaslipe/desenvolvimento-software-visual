import { useState } from "react";
import Produto from "../../../Models/Produto";

function CadastarProduto(){
    const [nome, setNome] = useState("");

    function submeterProdutoAPI(e : any){
        e.preventDefault()
        enviarProdutoAPI();
    }

    function escreverTxtNome(nome : any){
        console.log(nome.target.value);
    }

    async function enviarProdutoAPI() {
        const produto : Produto = {
            nome : nome,
            quantidade : 123,
            preco : 39.90,
        };

        const resposta = await fetch("http://localhost:5081/api/produto/cadastrar", {
            method : "POST",
            headers : {
                "Content-Type" : "application/json"
            },
            body : JSON.stringify(produto)
        })

        console.log(resposta);
    }
    return(
        <div>
            <h1>Cadastrar Produto</h1>

            <form onSubmit={submeterProdutoAPI}>
                <div>
                    <label htmlFor="">Nome</label>
                    <input type="text" name="" id="" onChange={escreverTxtNome}/>
                </div>
                <div>
                    <label htmlFor="">Quantidade</label>
                    <input type="text" name="" id="" />
                </div>
                <div>
                    <label htmlFor="">Preço</label>
                    <input type="text" name="" id="" />
                </div>
                <div>
                    <button type="submit">Cadastrar</button>
                </div>
            </form>
        </div>
    );
}

export default CadastarProduto;