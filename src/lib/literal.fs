\ lib/literal.fs

\ This file is part of Sin Forth.

\ This file adds `literal` to the compiler.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: literal ( x -- )
  h ldp#, \ ld hl,x
  push-hl ;

  \ doc{
  \
  \ literal
  \   Compilation: ( x -- )
  \   Run-time:    ( -- x )
  \
  \ Compilation: ( x -- )
  \
  \ Compile the code required to put cell _x_ on the stack at run-time.
  \
  \ Run-time: ( -- x )
  \
  \ Return the compiled cell _x_.
  \
  \ // XXX TODO
  \ // See also: `lit`, `cliteral`, `2literal`, `xliteral`.
  \
  \ }doc

set-current set-order
