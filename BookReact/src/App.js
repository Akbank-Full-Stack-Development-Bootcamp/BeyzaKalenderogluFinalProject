import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import React from "react";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import Authors from "./components/Authors";
import Publishers from "./components/Publishers";
import Books from "./components/Books";
import AuthorBooks from "./components/AuthorBooks"
import CategoryBooks from   "./components/CategoryBooks"
import CardDetail from "./components/CardDetail"
import PublisherBooks from "./components/PublisherBooks"
const App = () => {
  
    return (
      <Router>
        <>
          <Navbar />
          <Switch>
            <Route exact path="/">
              <Books />
            </Route>
            <Route exact path="/authors">
              <Authors />
            </Route>
            <Route exact path="/publishers">
              <Publishers />
            </Route>
            <Route exact path='/authors/:id' component={AuthorBooks}/>
            <Route exact path='/publishers/:id' component={PublisherBooks}/>
            <Route exact path='/categories/:id' component={CategoryBooks}/>
            <Route path='/books/:id' component={CardDetail}/>
            <Route path='/category/books/:id' component={CardDetail}/>
            <Route path='/authors/books/:id' component={CardDetail}/>
            <Route path='/publishers/books/:id' component={CardDetail}/>
          </Switch>
          <Footer/>
        </>
      </Router>
    );
  
}

export default App;
