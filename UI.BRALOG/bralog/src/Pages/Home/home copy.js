import React, { Component } from 'react';
import SideBar from '../../Components/Sidebar'
import '../../Assets/css/App.css';
// import '../../assets/style/style.css';

class Home extends Component {
  constructor(props){
      super(props);
      this.state = {
          email : '',
          senha : '',
          erroMensagem : '',
          isLoading : false
      }
  };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <div className='flex'>
                <SideBar/>
                <div className='pages'>
                <div>
                    <h1>clientes</h1> 
                    <div>
                    filter
                    </div>
                    <div>
                        table
                    </div> 
                </div>
            </div>   
            </div>
                  
        )
    }
};

export default Home;