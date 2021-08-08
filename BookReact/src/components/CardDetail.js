import React, { useState, useEffect } from 'react'

function CardDetail(props) {

    const[book, setBook] = useState({
        author:{}
    })
    
    useEffect(() => {

        const getBook = () => {
            fetch(`https://localhost:44318/api/books/${props.match.params.id}/detail`)
              .then((response) => response.json())
              .then(json => setBook(json))
        }
        getBook()
    },[props.match.params.id])
    
    
    return (
        
        <main> 
                <div className="container float-left d-flex justify-content-between mt-5" >
                    <img src={book.coverImagePath} className="img-fluid flex-fill mr-5" alt="Example" width="400" height="100" loading="lazy"/>
                    <div className="text-center flex-fill ml-5">
                        <h1 className="display-4 fw-bold">{book.title}</h1>
                        <p className="mb-4 display-4">{book.author.name} {book.author.lastname}</p>
                        <p className="mb-4 display-6">{book.author.about}</p>
                        <h1>{book.price} TL</h1>
                    </div>
                </div>        
        </main>   
    )
}

export default CardDetail
