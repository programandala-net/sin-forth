\ lib/c-variable.fs

\ This file is part of Sin Forth.

\ This file adds `cvariable` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012262212.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
