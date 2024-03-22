import React, { createContext, useContext, useState } from 'react';

// Create a new Context object for the learning feature, specifically for managing flashcards.
// Context provides a way to pass data through the component tree without having to pass props down manually at every level.
const LearnContext = createContext();

// Define a custom hook, 'useLearn', for easy access to the LearnContext.
// This hook simplifies the process of accessing LearnContext in functional components.
export function useLearn() {
    return useContext(LearnContext);
}

// Define the context provider component, 'LearnProvider', which will wrap part of the app's component tree and provide the context value to all components within that tree.
export function LearnProvider({ children }) {
    // useState hook initializes the 'flashcards' state variable with an empty array.
    // 'setFlashcards' is the function to update this state.
    const [flashcards, setFlashcards] = useState([]);

    // Define the context value that will be accessible to any child component of LearnProvider.
    // This includes the flashcards array and the setFlashcards function for updating it.
    const value = {
    flashcards,
    setFlashcards,
    };

    // Render the LearnContext.Provider component, passing the defined value to its 'value' prop.
    // 'children' represents any child components that LearnProvider wraps, allowing them access to the context.
  return <LearnContext.Provider value={value}>{children}</LearnContext.Provider>;
}