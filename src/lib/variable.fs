\ lib/variable.fs

\ This file is part of Sin Forth.

\ This file adds `variable` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: variable ( "name" -- )
  creator
  z80dasm-blocks @ if dup s" _variable_data" z80dasm-cell-block then
  , 2 memory> +!
  does> ( dfa ) @ h ldp#, push-hl ;

  \ doc{
  \
  \ variable
  \   Compilation: ( "name" -- )
  \   Run-time:    ( -- a )

  \
  \ Compilation: ( "name" -- )
  \
  \ Parse _name_.  Create a definition for _name_, which is referred
  \ to as a "variable".  `allot` one `cell` of data space, the data
  \ field of _name_, to hold the contents of the variable. When _name_
  \ is later executed, the address of its data field is placed on the
  \ stack.
  \
  \ The program is responsible for initializing the contents of the
  \ variable.
  \
  \ Run-time: ( -- a )
  \
  \ Place on the stack the data field address _a_ of _name_.

  \ // XXX TODO
  \ // See also: `2variable`
  \ See also: `@`, `!`, `cvariable`, `constant`, `create`.
  \
  \ }doc

set-current set-order
