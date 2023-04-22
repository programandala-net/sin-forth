\ lib/c-variable.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: cvariable ( "name" -- )
  creator
  z80dasm-blocks @ if dup s" _cvariable_data" z80dasm-char-block then
  , 1 memory> +!
  does> ( dfa ) @ h ldp#, push-hl ;

  \ doc{
  \
  \ cvariable
  \   Compilation: ( "name" -- )
  \   Run-time:    ( -- ca )
  \ "c-variable"

  \ Compilation: ( "name" -- )
  \
  \ Parse _name_.  Create a definition for _name_, which is referred
  \ to as a "character variable". `allot` one `char` of data space, the data
  \ field of _name_, to hold the contents of the variable. When _name_
  \ is later executed, the address of its data field is placed on the
  \ stack.
  \
  \ The program is responsible for initializing the contents of the
  \ variable.
  \
  \ Run-time: ( -- ca )
  \
  \ Place on the stack the data field address _ca_ of _name_.

  \ See also: `c!`, `c@`, `variable`, `cconstant`.
  \
  \ }doc

set-current set-order
