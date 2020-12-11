\ lib/literal.fs

\ This file is part of Sin Forth.

\ This file adds `literal` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111651.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

compiler-definitions

: literal ( x -- )
  h ldp#, \ ld hl,x
  target{ push-hl } ;

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
  \ Run-time:    ( -- x )
  \
  \ Return the compiled cell _x_.
  \
  \ // XXX TODO
  \ // See also: `lit`, `cliteral`, `2literal`, `xliteral`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Start.
\
\ 2020-12-11: Update the search-order selection words. Improve
\ documentation.
