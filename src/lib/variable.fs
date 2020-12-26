\ lib/variable.fs

\ This file is part of Sin Forth.

\ This file adds `variable` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012252043.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <sin_forth.fs>. Improve it with
\ `header`.
\
\ 2020-12-08: Create a z80dasm block.
\
\ 2020-12-10: Add stack notation to `does>` and simplify its code,
\ removing `evaluate`. Update with `creator`.
\
\ 2020-12-11: Update the search-order selection words. Fix the `does>`
\ code. Document.
\
\ 2020-12-13: Update: Remove `target{`.
\
\ 2020-12-25: Fix layout of the documentation. Add cross-reference to
\ `create`.
\
\ 2020-12-26: Update documentation with `cvariable`.
