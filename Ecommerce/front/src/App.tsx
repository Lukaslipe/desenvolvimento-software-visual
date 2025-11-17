import React from 'react';
import ListarProdutos from './Components/Pages/Produto/ListarProdutos';
import CadastarProduto from './Components/Pages/Produto/CadastrarProduto';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Link } from 'react-router-dom';
import AlterarProduto from './Components/Pages/Produto/AlterarProduto';

function App() {
  return (
    <div id="app">
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/">Listar produtos</Link>
            </li>
            <li>
              <Link to="/produto/cadastrar">Cadastrar produtos</Link>
            </li>
          </ul>
        </nav>

        <div id="conteudo">
          <Routes>
            <Route path='/' element={<ListarProdutos/>}></Route>
            <Route path='/produto/cadastrar' element={<CadastarProduto/>}></Route>
            <Route path='/produto/alterar/:id' element={<AlterarProduto/>}></Route>
          </Routes>
        </div>

        <footer>

        </footer>
        
      </BrowserRouter>
    </div>
  );
}

export default App;
