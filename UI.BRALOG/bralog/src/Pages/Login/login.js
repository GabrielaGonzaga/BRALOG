import React, { Component } from 'react';
import axios from 'axios';
import api from '../../Services/api';
// import '../../assets/style/style.css';

class Login extends Component {
  constructor(props){
      super(props);
      this.state = {
          email : '',
          senha : '',
          erroMensagem : '',
          isLoading : false
      }
  };

    EfetuarLogin = (event) => {
        event.preventDefault();
        this.setState({ erroMensagem : '', isLoading : true });

        // axios.post('http://18.206.0.185:5000/api/Adm/Login', {
        // axios.post('http://localhost:5000/api/Login/Login', {
        //     email : this.state.email,
        //     senha : this.state.senha
        // })

        api.post('/login/login', {
            email: this.state.email,
            senha: this.state.senha
        })

        .then(resposta => {
            if (resposta.status === 202) {
                localStorage.setItem('token', resposta.data.token);
                window.location.pathname = "/Home"
                this.setState({ isLoading : false })              
            }
        })
        .catch(() => {
            this.setState({ erroMensagem : 'e-mail ou senha inválidos,tente novamente!', isLoading : false });
        })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <div className="all">
                OII
                <form onSubmit={this.EfetuarLogin} autoComplete="off">
                        <div>
                            <h2>Login</h2>
                            <p>Digite seus dados para fazer login.</p>
                        </div>
                        <div>
                            <input
                                    id="email"
                                    // className="input__login"
                                    // E-mail
                                    type="text"
                                    name="email"
                                    // Define que o input email recebe o valor do state email
                                    value={this.state.email}
                                    // Faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Email"
                                    autoComplete="off"
                                />

                            <input
                                    id="senha"
                                    // E-mail
                                    type="password"
                                    name="senha"
                                    // Define que o input email recebe o valor do state email
                                    value={this.state.senha}
                                    // Faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                                    onChange={this.atualizaStateCampo}
                                    placeholder="Senha"
                                    autoComplete="off"
                                />
                                {
                                    this.state.isLoading === true &&
                                    <button 
                                        className='botaoLogin'
                                        type='submit' 
                                        disabled 
                                        style={{"backgroundColor": "grey"}}
                                    > Carregando... </button>
                                }
                                {
                                    this.state.isLoading === false &&
                                        <button 
                                            className='botaoLogin'
                                            type='submit'
                                        > Login </button>
                                }
                                <p className='Lerro'>{this.state.erroMensagem}</p>
                        </div>
                    </form>
            </div>
        )
    }
};

export default Login;