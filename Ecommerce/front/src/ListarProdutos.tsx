import { useEffect } from "react";
// Componente
// 1 - Por hora deve ser uma função
// 2 - Deve retornar apenas um elemento pai HTML
// 3 - Exportar o componente
// 4 - O nome da função deve estar em PascalCase

function ListarProdutos() {

    // UseEffect é o método que permite executar algum código no momento do carregamento do componente
 

    useEffect(() => {
        // Biblioteca AXIOS para requisições

        buscarProdutosAPI();

    }, []);

    async function buscarProdutosAPI(){
        try{
            const resposta = await fetch("http://localhost:5081/api/produto/listar");

            if (!resposta.ok) {
                throw new Error("Requisição com problema: " + resposta.statusText);
            }
            const dados = await resposta.json();
            
            console.table(dados);

        } catch(error) {
            console.log("Requisição com problemas" + error);
        }
    }

    return (
        <div id="listar_produtos">
            <h1>Listar Produtos</h1>
        </div>
    );
}

export default ListarProdutos;