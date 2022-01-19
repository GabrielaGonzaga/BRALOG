import React from 'react';
import '../../src/Assets/css/App.css';
import {SideBarData} from './SidebarData'
import logo1 from '../../src/Assets/img/logo1.png'

function SideBar() {
    return(
        <div className='Sidebarr'>
            <ul className='SidebarListr'>
            <img src={logo1} className='logo1' alt="Logo Bralog" />
                {SideBarData.map((val, key) =>{
                    return(
                        <div>
                            <li key={key} className='row' id= {window.location.pathname === val.link ? "active" : "out"}
                            onClick={()=> {window.location.pathname = val.link}}> {" "}                
                            <div className='icon' id= {val.title === "Sair" ? "sair" : "title"}>  
                                {val.icon} {" "} 
                            </div>
                            <div className='title' id= {val.title === "Sair" ? "sair" : "title"}>  
                                {val.title} {" "} 
                            </div>
                            </li>
                        </div>
                    );
                })}
            </ul> 
        </div>
    );
}

export default SideBar;

// {
//     return(
//         <li key={key} onClick={()=> {window.location.pathname = val.link}}> 
//         {" "}
//         <div> 
//             {val.icon}
//         </div>
//         {" "}
//         <div>
//             {val.title} 
//         </div>
//     </li>
//     )
// }