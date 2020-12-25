\ lib/ahead.fs

\ This file is part of Sin Forth.

\ This file adds `ahead` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012251740.
\ See change log at the end of the file.

\ ==============================================================

require branch.fs       \ `branch`
require forward-mark.fs \ `>mark`

get-order get-current

compiler-definitions

: ahead \ Compilation: ( C: -- orig )
        \ Run-time:    ( -- )
  $0000 compiler{ branch >mark } ;

  \ doc{
  \
  \ ahead
  \   Compilation: ( C: -- orig )
  \   Run-time:    ( -- )

  \
  \ Compilation: Compile an unconditional `branch` and put the
  \ location _orig_ of its unresolved destination on the
  \ control-flow stack.
  \
  \ Run-time: Continue execution at the location specified by the
  \ resolution of _orig_.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start.
\
\ 2020-12-25: Add `compiler{` to prevent `branch` and `>mark` be found
\ in the Gforth's word list first.
