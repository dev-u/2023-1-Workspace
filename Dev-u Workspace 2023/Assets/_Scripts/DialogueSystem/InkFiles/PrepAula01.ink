INCLUDE OtherFile.ink
VAR str = "Abracadabra"
->ExternalFunction

EXTERNAL TriggerAlgo()

=== abr(str2) ===

LINHA 1
LINHA 2
LINHA 3

{str}

-> ChoiceKnot

=== ChoiceKnot ===

Eu tenho uma dúvida:
Roxo é a melhor cor?
    *[Sim] Obviamente
        Top, também acho
        ->ChoiceKnot
    *Claro
        Muito perspicaz!
        Toma uma estrela
        ->ChoiceKnot
    * ->
        Chega, fera

->DONE

=== StickyChoiceKnot ===

Roxo é a melhor cor?
    +[Sim]
        Top, também acho
        ->ChoiceKnot
    +Claro
        Muito perspicaz!
        Toma uma estrela
        ->StickyChoiceKnot
    + ->
        Chega, fera

->DONE

=== Variables ===

VAR myInt = 5
VAR myBool = false


~ myInt = 6

meu inteiro: {myInt}
meu bool: {myBool}
minha string: {str}

->DONE

=== GathersAndNestedChoices ===

Roxo é a melhor cor?

    *Sim
        Sério mesmo?
            ** Não tava zoando
            ** Obviamente
        -- Eu sabia!!
    *Claro
        Muito perspicaz!
        Toma uma estrela
        
-Chega de papo

->DONE

=== Tags ===

#author: Capucho #date: 27/03
LINHA 1
LINHA 2

LINHA 3 #author: Luan
LINHA 4
LINHA 5


-> DONE

=== ImportNewFiles ===

-> importedText

-> DONE

=== ExternalFunction === 

~ TriggerAlgo()

->DONE


