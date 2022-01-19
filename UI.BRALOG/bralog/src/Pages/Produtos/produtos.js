import React, { Component, Fragment} from 'react';
import SideBar from '../../Components/Sidebar'
import api from '../../Services/api';
import axios from 'axios';
import '../../Assets/css/App.css';
import ReadOnlyRow from '../../Components/ReadOnlyRow'
import RefreshIcon from '@mui/icons-material/RefreshOutlined';
import EditableRow from '../../Components/EditableRow'
// import '../../assets/style/style.css';

require("es6-promise").polyfill();
require("isomorphic-fetch")

class Home extends Component {
  constructor(props){
      super(props);
      this.state = {
          listaProdutos : [], 
          idProduto : 0,
          descricao : '',
          setQ : '',
          Q : '',
          valor : '',
          qtd : 0,
          erroMensagem : '',
          isLoading : false
      }
  };

    RefreshPage(){
        window.location.reload();
    } 

  buscarProdutos = async () => {
    const resposta = await api.get("/Produto")

    this.setState({ listaProdutos: resposta.data })
    console.log(resposta.data)
    };

    componentDidMount(){
        this.buscarProdutos();
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <div className='flex'>
                <SideBar/>
                <div className='pages'>
                <div>
                    <h1>Produtos</h1> 
                    <div className='ref'>
                        <button type="submit" className='refreshbtn' onClick={this.RefreshPage}><RefreshIcon/></button>
                    </div>

                   
                    <div className="app-container">
      <form >
        <table>
        <thead id='thead'>
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Produto</th>
                <th scope="col">Qtd</th>
                <th scope="col">Valor</th>
                <th scope="col"> </th>
            </tr>
        </thead>
        
        <tbody>
        {
            this.state.listaProdutos.map((produto) => {
                return(
                <tr>
                    <td>{produto.idProduto}</td>
                    <td>{produto.descricao}</td>
                    <td>{produto.qtd}</td>
                    <td>{produto.valor}</td>
                    <button
                    
                    >Editar</button>
                    <button>Excluir</button>
                </tr>
                )  
            })
        }
        </tbody>
        </table>
      </form>
                    </div>
                    <div>  
                        {/* <form>
                             <table id='table' class="table table-striped">
                                <thead id='thead'>
                                    <tr>
                                        <th scope="col">Id</th>
                                        <th scope="col">Produto</th>
                                        <th scope="col">Qtd</th>
                                        <th scope="col">Valor</th>
                                        <th scope="col"> </th>
                                    </tr>
                                </thead>

                                <tbody>
                                {
                                    this.state.listaProdutos.map((produto) => {
                                        return(
                                            <Fragment> 
                                                <tr>
                                                    <td>{produto.idProduto}</td>
                                                    <td>{produto.descricao}</td>
                                                    <td>{produto.qtd}</td>
                                                    <td>{produto.valor}</td>
                                                </tr>
                                                <ReadOnlyRow>
                                               
                                                </ReadOnlyRow>
                                                
                                            </Fragment>  
                                        )  
                                    })
                                }
                                </tbody>
                        </table>
                    </form>   */}
                    </div>  
                </div>
            </div>   
            </div>
                  
        )
    }
};

export default Home;