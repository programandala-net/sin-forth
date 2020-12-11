\ lib/constant.fs

\ This file is part of Sin Forth.

\ This file adds `constant` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111810.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: constant ( "name" x -- )
  creator
  z80dasm-blocks @ if dup s" _constant_data" z80dasm-cell-block then
  dup , t-!  2 memory> +!
  does> ( dfa ) @ fthl, target{ push-hl } ;

  \ doc{
  \
  \ constant  Compilation: ( x "name" -- )
  \           Run-time:    ( -- x )
  \
  \ Compilation: ( x "name" -- )
  \
  \ Parse _name_. Create a definition for _name_ that will place _x_
  \ on the stack. _name_ is referred to as a "constant".
  \
  \ Run-time: ( -- x )
  \
  \ Place _x_ on the stack.
  \
  \ // XXX TODO
  \ // See also: `2constant`, `cconstant`, `fconstant`, `const`,
  \ // `[const]`, `variable`.
  \ See also: `variable`, `!>`.
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
\ 2020-12-09: Fix the Z80 instruction.
\
\ 2020-12-10: Add stack notation to `does>` and simplify its code,
\ removing `evaluate`. Update with `creator`.
\
\ 2020-12-11: Update the search-order selection words. Document.
