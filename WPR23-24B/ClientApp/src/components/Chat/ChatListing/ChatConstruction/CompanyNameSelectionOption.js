

import Form from 'react-bootstrap/Form';

export default function CompanyName(props)
{



    const CompanyDetails = {
        name: props.name,
        id: props.id
    }





    return (
    

        <option>{CompanyDetails}</option>
    
    
    
    
    )



}