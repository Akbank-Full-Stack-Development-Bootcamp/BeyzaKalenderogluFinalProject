import React, { useState } from 'react'

const Search = (props) => {

    const [term, setTerm] = useState("")

    const handleOnSubmit = (event) => {

        event.preventDefault()
        props.searchBook(term)
        
    }

    const handleOnChange = (event) => {
        //this.setState({term: event.target.value})
        setTerm(event.target.value)
    }

        
        return (
            <form onSubmit={handleOnSubmit} className="row g-3 mt-5 mb-5">
                <div className="col-10">
                    <input onChange={handleOnChange} type="text" className="form-control" placeholder="Search..." value={term}/>
                </div>
                <div className="col-2">
                <input type="submit" value="Search" placeholder="Search.." className="form-control btn btn-danger text-white"disabled = {!(term)}/>
                </div>
            </form>
        );

}

export default Search
