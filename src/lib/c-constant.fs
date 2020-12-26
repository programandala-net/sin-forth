\ lib/c-constant.fs

\ This file is part of Sin Forth.

\ This file adds `cconstant` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260213.
\ See change log at the end of the file.

\ ==============================================================

require push-a.fs \ `push-a`

get-order get-current

compiler-definitions

: cconstant ( c "name" -- )
  creator
  z80dasm-blocks @ if dup s" _cconstant_data" z80dasm-char-block then
  dup , t-c!  1 memory> +!
  does> ( dfa ) @ fta, push-a ;

  \ doc{
  \
  \ cconstant ( c "name" -- ) "c-constant"
  \
  \ Parse _name_. Create a definition for _name_ that will place
  \ _c_ on the stack. _name_ is referred to as a "c-constant".
  \
  \ // XXX TODO
  \ // See also: `constant`, `2constant`, `c!>`, `cconst`,
  \ // `[cconst]`, `cvalue`, `cvariable`.
  \
  \ See also: `constant`. 
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
