import React from 'react';
// import Icon1 from '../Assets/icons/clientes.png'
// import Icon2 from '../Assets/icons/entregas.png'
// import Icon3 from '../Assets/icons/produtos.png'
// import Icon4 from '../Assets/icons/configuracoes.png'
// import Icon5 from '../Assets/icons/dashboard.png'
// import Icon6 from '../Assets/icons/eu.png'
// import Icon7 from '../Assets/icons/sair.png'
import Icon1 from '@mui/icons-material/PeopleAltOutlined';
import Icon2 from '@mui/icons-material/LocalShippingOutlined';
import Icon3 from '@mui/icons-material/ShoppingBagOutlined';
import Icon4 from '@mui/icons-material/SettingsOutlined';
import Icon5 from '@mui/icons-material/DashboardOutlined';
import Icon6 from '@mui/icons-material/PersonOutlineOutlined';
import Icon7 from '@mui/icons-material/LogoutOutlined';
import '../../src/Assets/css/App.css';

export const SideBarData =[

    {
        title: "Home",
        icon: <Icon1/>,
        link: "/Home"
    },

    {
        title: "Entregas",
        icon: <Icon2/>,
        link: "/Entregas"
    },

    {
        title: "Produtos",
        icon: <Icon3/>,
        link: "/Produtos"
    },

    {
        title: "Configurações",
        icon: <Icon4/>,
        link: "/Configurações"
    },

    {
        title: "DashBoard",
        icon: <Icon5/>,
        link: "/DashBoard"
    },

    {
        title: "Eu",
        icon: <Icon6/>,
        link: "/Eu"
    },

    {
        title: "Sair",
        icon: <Icon7/>
    },

]

